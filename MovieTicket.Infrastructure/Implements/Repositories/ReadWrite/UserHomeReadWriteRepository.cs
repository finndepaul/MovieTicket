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

        public async Task<string> CreateCheckAsyc(CreateCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //decimal total = 0;
                //List<BillSeat> lstBillSeats = new List<BillSeat>();
                //foreach (var item in request.LstTicketPriceIds)
                //{
                //    var price = await _context.TicketPrices.FirstOrDefaultAsync(x => x.Id == item, cancellationToken);
                //    total += price.Price.Value;
                //}
                //var bill = new Bill
                //{
                //    Id = Guid.NewGuid(),
                //    MembershipId = request.AccountId,
                //    VoucherId = null,
                //    TotalMoney = total,
                //    CreateTime = DateTime.Now,
                //    BarCode = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                //    Status = BillStatus.Pending,
                //    ActivationStatus = false,
                //};
                //foreach (var item in request.LstSeatIds)
                //{
                //    lstBillSeats.Add(new BillSeat
                //    {
                //        BillId = bill.Id,
                //        SeatId = item
                //    });
                //}
                //await _context.Bills.AddAsync(bill, cancellationToken);
                //await _context.BillSeats.AddRangeAsync(lstBillSeats, cancellationToken);
                //await _context.SaveChangesAsync(cancellationToken);
                //return "Success";

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> DeleteCheckAsyc(Guid billId, CancellationToken cancellationToken)
        {
            //try
            //{
            //    var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == billId, cancellationToken);
            //    if (bill == null)
            //    {
            //        return "Bill not found";
            //    }
            //    var billSeat = await _context.BillSeats.Where(x => x.BillId == billId).ToListAsync(cancellationToken);
            //    _context.Bills.Remove(bill);
            //    _context.BillSeats.RemoveRange(billSeat);
            //    await _context.SaveChangesAsync(cancellationToken);
            //    return "Success";
            //}
            //catch (Exception ex)
            //{
            //    return "Error: " + ex.Message;
            //}
            throw new NotImplementedException();
        }

        public async Task<string> UpdateCheckAsyc(UpdateCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == request.BillId, cancellationToken);
                //if (bill == null)
                //{
                //    return "Bill not found";
                //}
                //List<BillCombo> lstBillCombo = new List<BillCombo>();
                //foreach (var item in request.LstComboId)
                //{
                //    lstBillCombo.Add(new BillCombo
                //    {
                //        BillId = request.BillId,
                //        ComboId = item
                //    });
                //}
                //var ticket = new Ticket
                //{
                //    Id = Guid.NewGuid(),
                //    BillId = request.BillId,
                //    ShowTimeId = request.ShowTimeId,
                //};
                //await _context.BillCombos.AddRangeAsync(lstBillCombo, cancellationToken);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        #region Private Methods

        private string DayOfTheWeek(string day) //check ngày
        {
            if (day.Equals("Saturday") || day.Equals("Sunday"))
            {
                return "T7-CN";
            }
            else
            {
                return "T2-T6";
            }
        }

        #endregion Private Methods
    }
}