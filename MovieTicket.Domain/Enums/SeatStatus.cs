using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Domain.Enums
{
    public enum SeatStatus
    {
            Available = 1, //chưa chọn
            Booked = 2, //đã đặt
            Reserved = 3, //đang chọn
            Unavailable = 4 //không thể chọn
    }
}
