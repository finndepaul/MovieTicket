using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.ValueObjs.Paginations
{
	public class PagingLink
	{
		// Thuộc tính Text lưu trữ văn bản hiển thị của liên kết phân trang (ví dụ: "Trang 1").
		public string Text { get; set; }

		// Thuộc tính Page lưu trữ số trang tương ứng với liên kết này.
		public int Page { get; set; }

		// Thuộc tính Enabled cho biết liên kết có khả dụng hay không (true là có thể nhấn, false là không thể nhấn).
		public bool Enabled { get; set; }

		// Thuộc tính Active cho biết liên kết hiện tại có đang hoạt động hay không (ví dụ: đang ở trang hiện tại).
		public bool Active { get; set; }

		// Constructor này khởi tạo đối tượng PagingLink với các giá trị cụ thể cho Page, Enabled và Text.
		public PagingLink(int page, bool enabled, string text)
		{
			// Gán giá trị tham số page cho thuộc tính Page.
			Page = page;

			// Gán giá trị tham số enabled cho thuộc tính Enabled.
			Enabled = enabled;

			// Gán giá trị tham số text cho thuộc tính Text.
			Text = text;
		}
	}

}
