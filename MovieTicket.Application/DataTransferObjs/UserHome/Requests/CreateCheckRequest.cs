namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
	public class CreateCheckRequest
	{
		public Guid? AccountId { get; set; }
		public Guid ShowTimeId { get; set; }
		public List<TicketRequest> LstSeatAndTicketPrice { get; set; }
	}
}