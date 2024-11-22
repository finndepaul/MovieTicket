using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.BillCombo
{
	public class BillComboDto
	{
		public Guid? BillId { get; set; }
		public Guid? ComboId { get; set; }
		public string ComboName { get; set; }
		public decimal? Price { get; set; }
		public int Quantity { get; set; }
		public decimal? TotalPrice { get; set; }
	}
}
