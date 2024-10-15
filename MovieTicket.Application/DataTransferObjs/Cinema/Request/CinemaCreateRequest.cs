using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Cinema.Request
{
    public class CinemaCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid CinemaTypeId { get; set; }

        [Required]
        public Guid CinemaCenterId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Column { get; set; }

        [Required]
        [Range(1, 100)]
        public int Row { get; set; }

        [Required]
        public string Description { get; set; }
    }
}