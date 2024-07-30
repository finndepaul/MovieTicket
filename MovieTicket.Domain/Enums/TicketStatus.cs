using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Domain.Enums
{
    public enum TicketStatus
    {
        Unuse = 1, //chưa dùng
        Used = 2, //đã dùng
        Expired = 3 //hết hạn
    }
}
