using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MimeKit;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class EmailSenderRepository : IEmailSenderReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;

        public EmailSenderRepository(MovieTicketReadWriteDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseObject<Guid>> SendEmail(string email, EmailType type, CancellationToken cancellationToken)
        {
            var account = _db.Accounts.FirstOrDefault(x => x.Email == email);
            if (account != null)
            {
                var accountId = account.Id;
                var mail = "dangnguyen300708@gmail.com";
                var appPassword = "fkab oshv bwin jyay"; // Mã xác thực một lần tạo từ tài khoản Gmail của bạn
                var emailMessage = new MimeMessage();
                Random rand = new Random();
                var message = rand.Next(10000, 99999);
                emailMessage.From.Add(new MailboxAddress("VHD Cinemas", mail));
                emailMessage.To.Add(new MailboxAddress("Recipient Name", email));

                var bodyBuilder = new BodyBuilder();
                if (type == EmailType.ConfirmEmaiL)
                {
                    emailMessage.Subject = "Xác thực tài khoản";
                    bodyBuilder.HtmlBody = $@"
                <p>Xin chào,</p>
                <p>Bạn đã tạo tài khoản thành công. Vui lòng nhấp vào nút bên dưới để kích hoạt tài khoản:</p>
                <a href=""https://localhost:7239/thank-you/{accountId}"">
                <button style=""background-color: #4CAF50; color: white; padding: 10px 20px; border: none; font-size: 16px;"">Kích Hoạt</button>
                </a>";

                    emailMessage.Body = bodyBuilder.ToMessageBody();
                }

                if (type == EmailType.ForgotPassword)
                {
                    emailMessage.Subject = "Xác nhận thay đổi mật khẩu";
                    bodyBuilder.HtmlBody = $@"
                <p>Xin chào,</p>
                <p>Bạn đã khôi phục mật khẩu. Dưới đây là mã xác nhận tài khoản của bạn:</p>
                <a>
                   {message.ToString()}
                </a>
                <p>Mã sẽ có hiệu lực trong vòng 5 phút!</p>
                <p>Vui lòng không chia sẻ cho ai khác!</p>
                ";

                    emailMessage.Body = bodyBuilder.ToMessageBody();
                    var confirmedEmail = new ConfirmedEmail();
                    confirmedEmail.AccountId = account.Id;
                    confirmedEmail.IsConfirmed = false;
                    confirmedEmail.ConfirmCode = message.ToString();
                    confirmedEmail.ExpiryTime = DateTime.Now.AddMinutes(5);
                    _db.ConfirmedEmails.Add(confirmedEmail);

                    await _db.SaveChangesAsync();
                }

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(mail, appPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
                return new ResponseObject<Guid>
                {
                    Data = account.Id,
                    Message = $"Gửi mail thành công đến {email}",
                    Status = StatusCodes.Status200OK
                };
            }
            return new ResponseObject<Guid>
            {
                Data = Guid.Empty,
                Message = $"Gửi mail thất bại",
                Status = StatusCodes.Status400BadRequest
            };
        }

        public async Task SendEmailForCheckOutAsync(Guid billId, CancellationToken cancellationToken)
        {
            var bill = await _db.Bills.FirstOrDefaultAsync(x => x.Id == billId, cancellationToken);
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == bill.MembershipId, cancellationToken);
            var ticket = await _db.Tickets.FirstOrDefaultAsync(x => x.BillId == billId, cancellationToken);
            var showTime = await _db.ShowTimes.FirstOrDefaultAsync(x => x.Id == ticket.ShowTimeId, cancellationToken);
            var schedule = await _db.Schedules.FirstOrDefaultAsync(x => x.Id == showTime.ScheduleId, cancellationToken);
            var film = await _db.Films.FirstOrDefaultAsync(x => x.Id == schedule.FilmId, cancellationToken);
            var cinema = await _db.Cinemas.FirstOrDefaultAsync(x => x.Id == showTime.CinemaId, cancellationToken);
            var cinemaCenter = await _db.CinemaCenters.FirstOrDefaultAsync(x => x.Id == cinema.CinemaCenterId, cancellationToken);
            var billCombo = await _db.BillCombos.FirstOrDefaultAsync(x => x.BillId == bill.Id, cancellationToken);
            var combo = await _db.Combos.FirstOrDefaultAsync(x => x.Id == billCombo.ComboId, cancellationToken);
            if (account != null)
            {
                var mail = "dangnguyen300708@gmail.com";
                var appPassword = "fkab oshv bwin jyay"; // Mã xác thực một lần tạo từ tài khoản Gmail của bạn
                var emailMessage = new MimeMessage();
                Random rand = new Random();
                var message = rand.Next(10000, 99999);
                emailMessage.From.Add(new MailboxAddress("VHD Cinemas", mail));
                emailMessage.To.Add(new MailboxAddress("Recipient Name", account.Email));

                var bodyBuilder = new BodyBuilder();

                emailMessage.Subject = "[VHDCinemas _Thông tin vé phim] - Đặt vé trực tuyến thành công / Your online ticket purchase has been successful";
                bodyBuilder.HtmlBody = $@"
                <h2>Xin chào {account.Name} / Hello {account.Name}</h2>
                <table style='border-collapse: collapse; width: 100%; margin-top: 20px; font-family: Arial, sans-serif;'>
                    <tr>
                        <th style='text-align: left;'>Mã vé (Reservation code):</th>
                        <td>{bill.BarCode}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Phim (Movie):</th>
                        <td>{film.Name}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Rạp (Theater):</th>
                        <td>{cinemaCenter.Name}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Phòng chiếu (Hall):</th>
                        <td>{cinema.Name}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Thời gian (Session):</th>
                        <td>{showTime.StartTime:dd/MM/yyyy HH:mm:ss}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Ghế (Seat):</th>
                        <td>{ticket.Seat}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Đồ ăn (Food):</th>
                        <td>{combo.Name}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Phương thức thanh toán (Payment method):</th>
                        <td>Chuyển khoản trực tuyến qua payOS</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Thời gian thanh toán (Payment Time):</th>
                        <td>{bill.CreateTime:dd/MM/yyyy HH:mm:ss}</td>
                    </tr>
                    <tr>
                        <th style='text-align: left;'>Tổng tiền (Total):</th>
                        <td>{bill.AfterDiscount} VND</td>
                    </tr>
                </table>
                <p style='margin-top: 20px;'>Lưu ý/Note:</p>
                <p>Vé đã mua không thể hủy, đổi hoặc trả lại. Vui lòng liên hệ Ban Quản Lý rạp hoặc tra cứu thông tin tại mục F.A.Q để biết thêm chi tiết. Cảm ơn bạn đã lựa chọn Beta Cinemas. Chúc bạn xem phim vui vẻ!</p>
                <p>Beta Cinemas does not offer refunds or exchanges for successful tickets purchased on our Betacineplex website. If you have any questions or problems with this order, you can Contact Us or see our F.A.Q for more information. Thank you for choosing Beta Cinemas and Enjoy the movie!</p>";

                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(mail, appPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
        }
    }
}