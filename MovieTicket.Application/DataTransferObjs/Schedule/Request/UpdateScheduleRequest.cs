using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Schedule.Request
{
    public class UpdateScheduleRequest
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}