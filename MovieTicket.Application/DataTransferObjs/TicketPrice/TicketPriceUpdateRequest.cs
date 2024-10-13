using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceUpdateRequest
    {
        public Guid? Id { get; set; }
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }

        public decimal? Price { get; set; }
		
		public TicketPriceStatus Status { get; set; }

        public bool Validate()
		{
			if (String.IsNullOrEmpty(SeatTypeId.ToString()))
			{
				return false;
			}
			if (String.IsNullOrEmpty(ScreenTypeId.ToString()))
			{
				return false;
			}
			if (String.IsNullOrEmpty(ScreeningDayId.ToString()))
			{
				return false;
			}
			if (String.IsNullOrEmpty(CinemaTypeId.ToString()))
			{
				return false;
			}
			if (String.IsNullOrEmpty(Price.ToString()))
			{
				return false;
			}
			return true;
		}
	}
}