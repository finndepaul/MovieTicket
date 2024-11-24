using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
	public class BillWithPaginationRequest
	{
		public string? BarCode { get; set; }

		public string? FilmName { get; set; }
		public string? CinemaType_Name { get; set; }

		public BillStatus? Status { get; set; }

		public ScheduleType? Type { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }

	}
}
