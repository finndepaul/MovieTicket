using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.AdminHome
{
    public class RevenueByMonthDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal? TotalRevenue { get; set; }
    }
}
