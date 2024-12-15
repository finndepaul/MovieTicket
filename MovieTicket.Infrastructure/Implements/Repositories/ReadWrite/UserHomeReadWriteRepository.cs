using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class UserHomeReadWriteRepository : IUserHomeReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _context;

        public UserHomeReadWriteRepository(MovieTicketReadWriteDbContext context)
        {
            _context = context;
        }

        public async Task<string> CheckOutSuccessAsync(CheckOutSuccessRequest request, CancellationToken cancellationToken)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == request.BillId, cancellationToken);
            var membership = await _context.Memberships.FirstOrDefaultAsync(x => x.AccountId == bill.AccountId, cancellationToken);
            if (bill == null)
            {
                return "Bill not found";
            }
            bill.Status = BillStatus.Paid;
            // Cộng điểm thành viên cho khách
            if (bill.TotalMoney == bill.AfterDiscount) // Nếu không sử dụng mã giảm giá thì mới đc công điểm
            {
                var member = await _context.Memberships.FirstOrDefaultAsync(x => x.Id == membership.Id);
                var point = bill.TotalMoney.Value * (decimal)0.03;
                member.Point = (int)(point + 0.5m) / 1000; // 3% giá trị hóa đơn
                _context.Memberships.Update(member);
            }
            // Sử dụng điểm thành viên VHD
            if (request.MembershipPoint > 0)
            {
                var member = await _context.Memberships.FirstOrDefaultAsync(x => x.Id == membership.Id);
                member.Point -= request.MembershipPoint;
                bill.MembershipId = member.Id;
                _context.Memberships.Update(member);
            }
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync(cancellationToken);
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
                    AccountId = (Guid)request.AccountId,
                    CouponId = null,
                    TotalMoney = total,
                    AfterDiscount = total,
                    CreateTime = DateTime.Now,
                    BarCode = DateTime.Now.ToString("yyyyMMddHHmmss"),
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
                        Price = _context.TicketPrices.FindAsync(item.TicketPriceId).Result.Price.Value,
                        Qrcode = DateTime.Now.ToString("MMddHHmmss"),
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
        public async Task<string> UpdateCheckMembershipIdAsync(Guid billId, string sdt, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Phone == sdt, cancellationToken);
            if (account == null)
            {
                return "Không tìm thấy tài khoản thành viên";
            }
            var membership = await _context.Memberships.FirstOrDefaultAsync(x => x.AccountId == account.Id, cancellationToken);
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == billId, cancellationToken);
            if (bill == null)
            {
                return "Bill not found";
            }
            bill.MembershipId = membership.Id;
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync(cancellationToken);
            return "Success";
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
                if (bill.Status == BillStatus.Paid)
                {
                    return "Hóa đơn này đã thanh toán không xóa được";
                }
                var lstTickets = await _context.Tickets.Where(x => x.BillId == billId).ToListAsync(cancellationToken);
                var lstBillCombos = await _context.BillCombos.Where(x => x.BillId == billId).ToListAsync(cancellationToken);
                _context.Bills.Remove(bill);
                _context.Tickets.RemoveRange(lstTickets);
                _context.BillCombos.RemoveRange(lstBillCombos);
                await _context.SaveChangesAsync(cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> AddComboToCheckAsync(ComboCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
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
                            ComboId = item.ComboId,
                            Quantity = item.Quantity,
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
                    await _context.BillCombos.AddRangeAsync(lstBillCombo, cancellationToken);
                    _context.Bills.Update(bill);
                }
                await _context.SaveChangesAsync(cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> AddDiscountToCheckAsync(DiscountCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == request.BillId, cancellationToken);
                if (bill == null)
                {
                    return "Bill not found";
                }
                if (request.CouponCode != null)
                {
                    var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode.Trim().Equals(request.CouponCode.Trim()));
                    if (coupon == null) return "Không tìm thấy mã giảm giá";
                    else if (!coupon.IsActive) return "Chương trình giảm giá chưa được kích hoạt";
                    else if (coupon.StartDate > DateTime.Now) return "Chương trình khuyến mãi chưa được áp dụng";
                    else if (coupon.EndDate < DateTime.Now) return "Chương trình khuyến mãi đã hết hạn";
                    bill.CouponId = coupon.Id;
                    bill.AfterDiscount = bill.TotalMoney - coupon.AmountValue;
                    if ((double)(bill.AfterDiscount / bill.TotalMoney) <= 0.1)
                    {
                        return "Coupon không được vượt quá 90% giá trị hóa đơn";
                    }
                    _context.Bills.Update(bill);
                }
                if (request.Point > 0)
                {
                    var member = await _context.Memberships.FirstOrDefaultAsync(x => x.AccountId == bill.AccountId, cancellationToken);
                    if (request.Point > member.Point) return "Điểm tích lũy không đủ";
                    if (request.Point < 10) return "Phải sử dụng tối thiêu 10 VHD Point";
                    bill.AfterDiscount = bill.AfterDiscount - ((decimal)request.Point * 1000);
                    if ((double)(bill.AfterDiscount / bill.TotalMoney) <= 0.1)
                    {
                        return "Điểm thưởng không được vượt quá 90% giá trị hóa đơn";
                    }
                    _context.Bills.Update(bill);
                }
                await _context.SaveChangesAsync(cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<bool> ResetDiscountAsync(Guid billId, CancellationToken cancellationToken)
        {
            var bill = await _context.Bills.FindAsync(billId, cancellationToken);
            if (bill == null) return false;
            bill.AfterDiscount = bill.TotalMoney;
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}