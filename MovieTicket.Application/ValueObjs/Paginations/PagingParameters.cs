using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.ValueObjs.Paginations
{
	public class PagingParameters
	{
		const int maxPageSize = 30; //Số lượng phần tử tối đa trên mỗi trang
		public int PageNumber { get; set; } = 1; //Trang hiện tại
		private int _pageSize = 5; //Số lượng phần tử trên mỗi trang
		public int PageSize // Nếu PageSize quá 30 giữ liệu ở trong thì sẽ chuyển về maxPageSize = 30
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
