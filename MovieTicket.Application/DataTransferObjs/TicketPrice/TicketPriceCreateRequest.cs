namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceCreateRequest
    {
        public Guid SeatTypeId { get; set; } // Loại ghế VIP , thường , đôi , đơn
		public Guid ScreenTypeId { get; set; } //hình thức chiếu phim 2D , 3D , 4D 
		public Guid ScreeningDayId { get; set; } //ngày chiếu ngày thường , cuối tuần
		public Guid CinemaTypeId { get; set; } //loại phòng chiếu Imax , goodly class , tiêu chuẩn
		public decimal Price { get; set; }

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