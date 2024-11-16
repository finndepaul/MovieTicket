using MovieTicket.Application.DataTransferObjs.TicketPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
    public class CreateCheckRequest
    {
        public Guid AccountId { get; set; }
        public Guid ShowTimeId { get; set; }
        public List<TicketRequest> LstSeatAndTicketPrice { get; set; }
    }
}