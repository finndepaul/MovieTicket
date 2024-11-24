using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Ticket
{
	public class TicketDto
	{
		public Guid Id { get; set; }
		public Guid? BillId { get; set; }
		public Guid? ShowTimeId { get; set; }
		public Guid? SeatId { get; set; }
		public decimal Price { get; set; }
		public Guid? TicketPriceId { get; set; }
		public string? Qrcode { get; set; }
		public string? Description { get; set; }
		public TicketStatus? Status { get; set; }
	}
}
