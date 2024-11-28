using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
	public class ShowTimeUpdateStatus
	{
		public Guid Id { get; set; }
		public ShowtimeStatus Status { get; set; }
	}
}
