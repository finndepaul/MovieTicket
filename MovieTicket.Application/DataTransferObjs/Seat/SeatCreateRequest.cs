namespace MovieTicket.Application.DataTransferObjs.Seat
{
    public class SeatCreateRequest
    {
        public Guid CinemaId { get; set; }
        public string Position { get; set; }
    }
}