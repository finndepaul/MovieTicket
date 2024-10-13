using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Banner
{
    public class BannerUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public BannerStatus Status { get; set; }
    }
}