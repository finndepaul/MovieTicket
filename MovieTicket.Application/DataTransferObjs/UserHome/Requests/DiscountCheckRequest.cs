using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
	public class DiscountCheckRequest
	{
		public Guid BillId { get; set; }
		public string? CouponCode { get; set; }
		public int? Point { get; set; }
	}
}