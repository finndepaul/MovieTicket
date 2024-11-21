using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Domain.Entities
{
    public class About
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

    }
}
