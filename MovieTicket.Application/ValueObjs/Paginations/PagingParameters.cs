using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.ValueObjs.Paginations
{
	public class PagingParameters
	{
		public int PageNumber { get; set; } = 1; //Trang hiện tại
		public int PageSize { get; set; } = 5; //Số lượng phần tử trên mỗi trang
	}
}
