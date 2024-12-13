using ZXing;
using ZXing.Common;
using System;
using SixLabors.ImageSharp;

namespace WebUI.Helper
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
				Format = BarcodeFormat.CODE_128,
				Options = new EncodingOptions
				{
					Height = 100,
					Width = 300,
					Margin = 10
				}
			};

			// Tạo dữ liệu pixel từ mã vạch
			var pixelData = writer.Write(barcodeContent);

			// Tạo hình ảnh dưới dạng Base64 mà không sử dụng System.Drawing
			string base64Barcode;
			using (var ms = new System.IO.MemoryStream())
			{
				// Xuất pixel thành định dạng PNG
				using (var image = SixLabors.ImageSharp.Image.LoadPixelData<SixLabors.ImageSharp.PixelFormats.Rgba32>(
					pixelData.Pixels,
					pixelData.Width,
					pixelData.Height))
				{
					image.SaveAsPng(ms);
				}
				base64Barcode = Convert.ToBase64String(ms.ToArray());
			}

			return $"data:image/png;base64,{base64Barcode}";
		}
	}
}