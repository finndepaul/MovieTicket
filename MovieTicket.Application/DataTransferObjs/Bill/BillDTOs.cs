using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
    public class BillDTOs
    {
        public Guid Id { get; set; }
        //public Guid? MembershipId { get; set; }

        //public Guid? VoucherId { get; set; }
        public decimal? TotalMoney { get; set; }

        public DateTime? CreateTime { get; set; }

        public string? BarCode { get; set; }

        public BillStatus? Status { get; set; }
        public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
    }

}
