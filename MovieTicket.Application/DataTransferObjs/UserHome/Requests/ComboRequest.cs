using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
    public class ComboRequest
    {
        public Guid ComboId { get; set; }
        public int Quantity { get; set; }
    }
}