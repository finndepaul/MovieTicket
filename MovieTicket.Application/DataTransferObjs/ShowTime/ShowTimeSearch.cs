using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
	public class ShowTimeSearch
	{
		public Guid? CinemaCenterId { get; set; }
		public Guid? CinemaId { get; set; }
		public DateTime? ShowtimeDate { get; set; }
	}
}
