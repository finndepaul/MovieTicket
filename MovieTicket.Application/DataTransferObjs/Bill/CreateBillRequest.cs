using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
    public class CreateBillRequest
    {

        public decimal? TotalMoney { get; set; }

        //public DateTime? CreateTime { get; set; }

        //public string? BarCode { get; set; }

        public int? Status { get; set; }
        public List<Guid>? ComboIds { get; set; }

    }

}
