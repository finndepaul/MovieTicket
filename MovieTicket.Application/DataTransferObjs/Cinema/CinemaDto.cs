using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Cinema
{
    public class CinemaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CinemaTypeName { get; set; }
        public string CinemaCenterName { get; set; }
        public int MaxSeatCapacity { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
