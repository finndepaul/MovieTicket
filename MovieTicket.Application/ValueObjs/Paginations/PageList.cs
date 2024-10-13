using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.ValueObjs.Paginations
{
	public class PageList<T>
	{
		public MetaData MetaData { get; set; } //Thuộc tính MetaData lưu trữ thông tin về siêu dữ liệu của trang 
		public IEnumerable<T> Item { get; set; } //Thuộc tính Item lưu trữ danh sách phần tử của trang
		public PageList() { } //Đây là constructor mặc định không có tham số.Nó khởi tạo một đối tượng PagedList mà không thiết lập bất kỳ thuộc tính nào.
		public PageList(IEnumerable<T> item, int count, int pageNumber, int pageSize)
		{
			MetaData = new MetaData() 
			{
				TotalCount = count, //Tổng số phần tử
				PageSize = pageSize, //Kích thước trang
				CurrentPage = pageNumber, //Trang hiện tại
				TotalPage = (int)Math.Ceiling(count / (double)pageSize) //Tổng số trang
			};
			Item = item; //Danh sách phần tử của trang
		}

	}
}
