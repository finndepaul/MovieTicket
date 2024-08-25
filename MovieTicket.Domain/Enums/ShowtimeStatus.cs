using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Domain.Enums
{
    public enum ShowtimeStatus
    {
        ComingSoon = 1, // Sắp ra mắt
        Showing = 2, // Đang chiếu
        Ended = 3, // Đã kết thúc
    }
}
