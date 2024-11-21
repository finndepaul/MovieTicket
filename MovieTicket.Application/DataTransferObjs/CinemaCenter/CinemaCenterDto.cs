namespace MovieTicket.Application.DataTransferObjs.CinemaCenter
{
    public class CinemaCenterDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
        public string AddresCity { get; set; }
        public string? AddressMap { get; set; }

		public DateTime? CreateDate { get; set; }
    }
}