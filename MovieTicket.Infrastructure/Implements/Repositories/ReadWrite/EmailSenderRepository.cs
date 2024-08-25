using Azure.Core;
using MailKit.Security;
using MimeKit;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class EmailSenderRepository : IEmailSenderReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;

        public EmailSenderRepository(MovieTicketReadWriteDbContext db)
        {
            _db = db;
        }

        public async Task<bool> SendEmail(string email, EmailType type, CancellationToken cancellationToken)
        {
            var account = _db.Accounts.FirstOrDefault(x => x.Email == email);
            if (account != null)
            {

                var mail = "dangnguyen300708@gmail.com";
                var appPassword = "fkab oshv bwin jyay"; // Mã xác thực một lần tạo từ tài khoản Gmail của bạn
                var emailMessage = new MimeMessage();
                Random rand = new Random();
                var message = rand.Next(10000, 99999);
                emailMessage.From.Add(new MailboxAddress("Demon Slayer Booking Ticket", mail));
                emailMessage.To.Add(new MailboxAddress("Recipient Name", email));
                emailMessage.Subject = "Xác nhận thay đổi mật khẩu";
                var bodyBuilder = new BodyBuilder();
                if (type == EmailType.ConfirmEmaiL)
                {
                    bodyBuilder.HtmlBody = $@"
                <p>Xin chào,</p>
                <p>Bạn đã tạo tài khoản thành công. Vui lòng nhấp vào nút bên dưới để kích hoạt tài khoản:</p>
                <a href=""https://example.com/confirm-password?code={message.ToString()}"">
                <button style=""background-color: #4CAF50; color: white; padding: 10px 20px; border: none; font-size: 16px;"">Kích Hoạt</button>
                </a>";

                    emailMessage.Body = bodyBuilder.ToMessageBody();

                }
                if (type == EmailType.ForgotPassword)
                {
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
                return true;
            }
            return false;
        }

    }
}
