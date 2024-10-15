namespace MovieTicket.Application.DataTransferObjs.Seat
{
    public class SeatUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? SeatTypeId { get; set; }
        public int Status { get; set; }
    }
}