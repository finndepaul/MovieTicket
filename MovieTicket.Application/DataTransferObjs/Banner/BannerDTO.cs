using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Banner
{
    public class BannerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public BannerStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}