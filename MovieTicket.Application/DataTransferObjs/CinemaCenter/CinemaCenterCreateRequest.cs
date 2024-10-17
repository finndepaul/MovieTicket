using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.CinemaCenter
{
    public class CinemaCenterCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}