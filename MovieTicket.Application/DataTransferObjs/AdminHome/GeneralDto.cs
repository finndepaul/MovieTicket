namespace MovieTicket.Application.DataTransferObjs.AdminHome
{
    public class GeneralDto
    {
        public decimal? DailyRevenue { get; set; }

        public int NewCustomer { get; set; }

        public decimal TotalTicketsSold { get; set; }

        public decimal? TotalRevenue { get; set; }
    }
}