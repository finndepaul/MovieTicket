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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing.Common;
using ZXing;

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
            var ticket =  _db.Tickets.Where(x => x.BillId == billId);
            var showTime = await _db.ShowTimes.FirstOrDefaultAsync(x => x.Id == ticket.FirstOrDefault().ShowTimeId, cancellationToken);
            var schedule = await _db.Schedules.FirstOrDefaultAsync(x => x.Id == showTime.ScheduleId, cancellationToken);
            var film = await _db.Films.FirstOrDefaultAsync(x => x.Id == schedule.FilmId, cancellationToken);
            var cinema = await _db.Cinemas.FirstOrDefaultAsync(x => x.Id == showTime.CinemaId, cancellationToken);
            var cinemaCenter = await _db.CinemaCenters.FirstOrDefaultAsync(x => x.Id == cinema.CinemaCenterId, cancellationToken);
            var billCombo = _db.BillCombos.Where(x => x.BillId == bill.Id);

            string comboString = string.Empty;
            List<Guid> lstSeatId = new List<Guid>();
            foreach (var item in ticket)
            {
                lstSeatId.Add(item.SeatId.Value);
            }
            List<string> lstSeat = new List<string>();
            foreach (var item in lstSeatId)
            {
                var seat = await _db.Seats.FirstOrDefaultAsync(x => x.Id == item, cancellationToken);
                lstSeat.Add(seat.Position);
            }
            string seatString = string.Join(" ,", lstSeat);
            
            if (billCombo != null)
            {  
                List<Guid> lstBillCombo = new List<Guid>();
                foreach (var item in billCombo)
                {
                    lstBillCombo.Add(item.ComboId.Value);
                }
                List<string> lstCombo = new List<string>();
                foreach (var item in lstBillCombo)
                {
                    var dv = await _db.Combos.FirstOrDefaultAsync(x => x.Id == item, cancellationToken);
                    lstCombo.Add(dv.Name);
                }
                 comboString = string.Join(" ,", lstCombo);
            }
            if (account != null)
            {
                string barcodeFilePath = GenerateBarcodeToFile(long.Parse(bill.BarCode));
                var imageContentId = "barcodeImage";
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
                <table style=""border-collapse: collapse; width: 100%; margin-top: 20px; font-family: Arial, sans-serif;"">
                    <tr>
                        <th style=""text-align: left;"">Mã vé (Reservation code):</th>
                        <td><img src=""cid:{imageContentId}"" alt=""Barcode"" /></td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Phim (Movie):</th>
                        <td>{film.Name}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Rạp (Theater):</th>
                        <td>{cinemaCenter.Name}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Phòng chiếu (Hall):</th>
                        <td>{cinema.Name}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Thời gian (Session):</th>
                        <td>{showTime.StartTime?.ToString("dd/MM/yyyy HH:mm:ss")}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Ghế (Seat):</th>
                        <td>{seatString}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Dịch vụ mua kèm (Service):</th>
                        <td>{comboString}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Phương thức thanh toán (Payment method):</th>
                        <td>Chuyển khoản trực tuyến qua payOS</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Thời gian thanh toán (Payment Time):</th>
                        <td>{bill.CreateTime.ToString("dd/MM/yyyy HH:mm:ss")}</td>
                    </tr>
                    <tr>
                        <th style=""text-align: left;"">Tổng tiền (Total):</th>
                        <td>{bill.AfterDiscount?.ToString("#,##0")} VND</td>
                    </tr>
                </table>
                <p style='margin-top: 20px;'>Lưu ý/Note:</p>
                <p>Vé đã mua không thể hủy, đổi hoặc trả lại. Vui lòng liên hệ Ban Quản Lý rạp hoặc tra cứu thông tin tại mục F.A.Q để biết thêm chi tiết. Cảm ơn bạn đã lựa chọn VHD Cinemas. Chúc bạn xem phim vui vẻ!</p>
                <p>Beta Cinemas does not offer refunds or exchanges for successful tickets purchased on our Betacineplex website. If you have any questions or problems with this order, you can Contact Us or see our F.A.Q for more information. Thank you for choosing VHD Cinemas and Enjoy the movie!</p>";
                var barcodeImage = bodyBuilder.LinkedResources.Add(barcodeFilePath);
                barcodeImage.ContentId = imageContentId;
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(mail, appPassword);
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
                if (File.Exists(barcodeFilePath))
                {
                    File.Delete(barcodeFilePath);
                }
            }
        }
        private string GenerateBarcodeToFile(long number)
        {
            // Nội dung mã vạch
            string barcodeContent = number.ToString();

            // Cấu hình BarcodeWriter
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128, // Định dạng mã vạch
                Options = new EncodingOptions
                {
                    Height = 100, // Chiều cao mã vạch
                    Width = 300,  // Chiều rộng mã vạch
                    Margin = 10   // Lề
                }
            };

            // Tạo dữ liệu pixel từ mã vạch
            var pixelData = writer.Write(barcodeContent);

            // Chuyển dữ liệu pixel thành Bitmap
            using var barcodeBitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
            var bitmapData = barcodeBitmap.LockBits(
                new Rectangle(0, 0, barcodeBitmap.Width, barcodeBitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppRgb);

            try
            {
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                barcodeBitmap.UnlockBits(bitmapData);
            }

            // Kích thước ảnh cuối cùng (thêm không gian cho số và viền)
            int finalWidth = barcodeBitmap.Width + 40;  // Thêm 20px mỗi bên cho viền
            int finalHeight = barcodeBitmap.Height + 70; // Thêm không gian cho số và viền

            using var finalImage = new Bitmap(finalWidth, finalHeight);
            using (var graphics = Graphics.FromImage(finalImage))
            {
                // Đặt màu nền trắng
                graphics.Clear(Color.White);

                // Tăng chất lượng vẽ
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Tạo hình chữ nhật bo góc
                int borderRadius = 20; // Bán kính góc bo
                using var borderPen = new Pen(Color.Black, 3); // Viền đen, dày 3px

                // Vẽ hình chữ nhật bo góc
                using var path = new GraphicsPath();
                path.AddArc(5, 5, borderRadius, borderRadius, 180, 90); // Góc trên trái
                path.AddArc(finalWidth - borderRadius - 5, 5, borderRadius, borderRadius, 270, 90); // Góc trên phải
                path.AddArc(finalWidth - borderRadius - 5, finalHeight - borderRadius - 5, borderRadius, borderRadius, 0, 90); // Góc dưới phải
                path.AddArc(5, finalHeight - borderRadius - 5, borderRadius, borderRadius, 90, 90); // Góc dưới trái
                path.CloseFigure();

                graphics.DrawPath(borderPen, path);

                // Vẽ mã vạch ở giữa ảnh
                graphics.DrawImage(barcodeBitmap, 20, 20);

                // Vẽ số bên dưới mã vạch
                using var font = new Font("Arial", 16, FontStyle.Regular);
                using var brush = new SolidBrush(Color.Black);
                var stringSize = graphics.MeasureString(barcodeContent, font);
                graphics.DrawString(
                    barcodeContent,
                    font,
                    brush,
                    (finalWidth - stringSize.Width) / 2, // Căn giữa theo chiều ngang
                    barcodeBitmap.Height + 30           // Vị trí bên dưới mã vạch
                );
            }

            // Lưu ảnh thành tệp
            string filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
            finalImage.Save(filePath, ImageFormat.Png);

            return filePath;
        }




    }
}