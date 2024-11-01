using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.UserHome
{
    public class UserHomeDto
    {
        public Guid Id { get; set; }

        public string? Poster { get; set; }

        public string? Name { get; set; }

        public string? Gerne { get; set; }
        public int? RunningTime { get; set; }
		public int? Rating { get; set; }
		public DateTime? StartDate { get; set; }
        public ScheduleType? SType { get; set; }
    }
}