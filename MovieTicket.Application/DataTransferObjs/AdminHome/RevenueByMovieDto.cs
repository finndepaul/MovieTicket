using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.AdminHome
{
    public class RevenueByMovieDto
    {
		public string FilmName { get; set; }

		public int TotalTicket { get; set; }

		public decimal? TotalRevenue { get; set; }
	}
}
