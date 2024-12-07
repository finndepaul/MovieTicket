using ZXing.Common;
using ZXing;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MovieTicket.BlazorServer.Helper
{
	public class GeneratorBarcode
	{
		public string GenerateBarcode(long number)
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

			// Kích thước ảnh cuối cùng (thêm không gian cho số và viền bo góc)
			int finalWidth = barcodeBitmap.Width + 40;  // Thêm 20px mỗi bên cho viền
			int finalHeight = barcodeBitmap.Height + 70; // Thêm không gian cho số và viền

			using var finalImage = new Bitmap(finalWidth, finalHeight);
			using (var graphics = Graphics.FromImage(finalImage))
			{
				// Đặt màu nền trắng
				graphics.Clear(Color.White);

				// Tăng chất lượng vẽ
				graphics.SmoothingMode = SmoothingMode.AntiAlias;

				// Vẽ viền bo góc
				using var path = CreateRoundedRectanglePath(new Rectangle(5, 5, finalWidth - 10, finalHeight - 10), 20); // Bo góc 20px
				using var borderPen = new Pen(Color.Black, 3); // Viền đen, dày 3px
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

			// Chuyển ảnh thành Base64
			using var ms = new MemoryStream();
			finalImage.Save(ms, ImageFormat.Png);
			return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
		}

		// Hàm tạo đường viền bo góc
		private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
		{
			GraphicsPath path = new GraphicsPath();
			int diameter = cornerRadius * 2;

			// Góc trên bên trái
			path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
			// Góc trên bên phải
			path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
			// Góc dưới bên phải
			path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
			// Góc dưới bên trái
			path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
			path.CloseFigure();

			return path;
		}
	}

}
