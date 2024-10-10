namespace MovieTicket.Domain.Entities
{
    public class BillSeat
    {
        public Guid SeatId { get; set; }
        public Guid BillId { get; set; }

        public virtual Seat? Seat { get; set; }

        public virtual Bill? Bill { get; set; }
    }
}