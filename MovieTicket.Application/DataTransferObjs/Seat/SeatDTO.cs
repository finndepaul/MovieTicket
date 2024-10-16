using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Seat
{
    public class SeatDTO
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public string CinemaCenterName { get; set; }
        public string CinemaName { get; set; }
        public string SeatTypeName { get; set; }
        public string Position { get; set; }
        public SeatStatus Status { get; set; }
    }
}