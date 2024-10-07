using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.CinemaCenter
{
    public class CinemaCenterCreateRequest
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}