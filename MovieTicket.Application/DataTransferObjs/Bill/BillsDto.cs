using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
    public class BillsDto
    {
        public Guid Id { get; set; }

		public ScheduleType? Type { get; set; }
		public string CinemaType_Name { get; set; }
		public string FilmName { get; set; }
		public decimal? TotalMoney { get; set; }
		public DateTime? CreateTime { get; set; }
        public string? BarCode { get; set; }
		public BillStatus? Status { get; set; }

        public int? FilmRating { get; set; }
        public DateTime? ShowStartTime { get; set; }
        public DateTime? ShowEndTime { get; set; }
        public string? CinemaName { get; set; }
        public string? FilmPoster { get; set; }
    }
}
