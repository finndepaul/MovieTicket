using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
    public class BillDto
    {
        public Guid Id { get; set; }
		public Guid? MembershipId { get; set; }
		public string FilmName { get; set; }

        public decimal? TotalMoney { get; set; }

        public DateTime? CreateTime { get; set; }

        public string? BarCode { get; set; }

        public string Status { get; set; }
    }
}