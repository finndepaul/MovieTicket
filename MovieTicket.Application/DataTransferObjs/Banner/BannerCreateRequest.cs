using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Banner
{
    public class BannerCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
    }
}