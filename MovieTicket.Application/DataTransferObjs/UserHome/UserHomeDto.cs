using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome
{
    public class UserHomeDto
    {
        public Guid Id { get; set; }

        public string? Poster { get; set; }

        public string? Name { get; set; }

        public string? Gerne { get; set; }
        public int? RunningTime { get; set; }
		public ScheduleType? SType { get; set; }
	}
}
