using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Coupon
{
    public class CouponDto
    {
        public Guid Id { get; set; }
        public string CouponCode { get; set; }
        public decimal AmountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IsActive { get; set; }
    }
}