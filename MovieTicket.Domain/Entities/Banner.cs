using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities
{
    public class Banner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public BannerStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}