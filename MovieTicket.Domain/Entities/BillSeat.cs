using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Domain.Entities
{
    public class BillSeat
    {
        public Guid SeatId { get; set; }
        public Guid BillId { get; set; }

        public virtual Seat? Seat { get; set; }

        public virtual Bill? Bill { get; set; }
    }
}
