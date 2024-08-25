using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.CinemaCenter
{
    public class CinemaCenterDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }

}
