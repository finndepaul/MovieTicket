using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class UserHomeReadWriteRepository : IUserHomeReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _context;

        public UserHomeReadWriteRepository(MovieTicketReadWriteDbContext context)
        {
            _context = context;
        }

        public async Task<string> CheckOutSuccessAsync(Guid billId, CancellationToken cancellationToken)
        {
            var bill = _context.Bills.FirstOrDefault(x => x.Id == billId);
            if (bill == null)
            {
                return "Bill not found";
            }
            bill.Status = BillStatus.Paid;
            _context.Bills.Update(bill);
            _context.SaveChanges();
            return "Success";
        }

        public async Task<string> CreateCheckAsync(CreateCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                decimal total = 0;
                foreach (var item in request.LstSeatAndTicketPrice)
                {
                    var price = await _context.TicketPrices.FirstOrDefaultAsync(x => x.Id == item.TicketPriceId, cancellationToken);
                    total += price.Price.Value;
                }
                var bill = new Bill
                {
                    Id = Guid.NewGuid(),
                    MembershipId = request.AccountId,
                    CouponId = null,
                    TotalMoney = total,
                    AfterDiscount = total,
                    CreateTime = DateTime.Now,
                    BarCode = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Status = BillStatus.Pending,
                    ActivationStatus = false,
                };
                List<Ticket> lstTickets = new List<Ticket>();
                foreach (var item in request.LstSeatAndTicketPrice)
                {
                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        BillId = bill.Id,
                        ShowTimeId = request.ShowTimeId,
                        SeatId = item.SeatId,
                        TicketPriceId = item.TicketPriceId,
                        Qrcode = "TI" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                        Description = "Chưa sử dụng",
                        Status = TicketStatus.Unuse,
                    };
                    lstTickets.Add(ticket);
                }
                await _context.Bills.AddAsync(bill, cancellationToken);
                await _context.Tickets.AddRangeAsync(lstTickets, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return bill.Id.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> DeleteCheckAsync(Guid billId, CancellationToken cancellationToken)
        {
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == billId, cancellationToken);
                if (bill == null)
                {
                    return "Bill not found";
                }
                var lstTickets = await _context.Tickets.Where(x => x.BillId == billId).ToListAsync(cancellationToken);
                _context.Bills.Remove(bill);
                _context.Tickets.RemoveRange(lstTickets);
                await _context.SaveChangesAsync(cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> UpdateCheckAsync(UpdateCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // # Thanh toán có xử lý giảm giá - chưa xử lý xong
                //var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == request.BillId, cancellationToken);
                //if (bill == null)
                //{
                //    return "Bill not found";
                //}
                //List<BillCombo> lstBillCombo = new List<BillCombo>();
                //foreach (var item in request.LstCombos)
                //{
                //    lstBillCombo.Add(new BillCombo
                //    {
                //        BillId = request.BillId,
                //        ComboId = item.ComboId
                //    });
                //}
                //var total = bill.TotalMoney;
                //foreach (var item in lstBillCombo)
                //{
                //    var combo = await _context.Combos.FirstOrDefaultAsync(x => x.Id == item.ComboId, cancellationToken);
                //    total += combo.Price.Value * item.Quantity;
                //}
                //bill.TotalMoney = total;
                //// Coupon
                //var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode == request.CouponCode, cancellationToken);
                //if (coupon != null)
                //{
                //    coupon.AmountValue = total.Value - coupon.AmountValue;
                //}
                //else
                //{
                //    bill.CouponId = null;
                //}
                //bill.AfterDiscount = total;
                //// Membership

                //_context.Bills.Update(bill);
                //await _context.BillCombos.AddRangeAsync(lstBillCombo, cancellationToken);
                //await _context.SaveChangesAsync(cancellationToken);

                // # Thanh toán chưa chọn giảm giá
                var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == request.BillId, cancellationToken);
                if (bill == null)
                {
                    return "Bill not found";
                }
                List<BillCombo> lstBillCombo = new List<BillCombo>();
                if (request.LstCombos != null)
                {
                    foreach (var item in request.LstCombos)
                    {
                        lstBillCombo.Add(new BillCombo
                        {
                            BillId = request.BillId,
                            ComboId = item.ComboId
                        });
                    }
                    var total = bill.TotalMoney;
                    foreach (var item in lstBillCombo)
                    {
                        var combo = await _context.Combos.FirstOrDefaultAsync(x => x.Id == item.ComboId, cancellationToken);
                        total += combo.Price.Value * item.Quantity;
                    }
                    bill.TotalMoney = total;
                    bill.AfterDiscount = total;
                    _context.Bills.Update(bill);
                    await _context.BillCombos.AddRangeAsync(lstBillCombo, cancellationToken);
                }
                await _context.SaveChangesAsync(cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}