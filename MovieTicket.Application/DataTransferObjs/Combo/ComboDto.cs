using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Combo
{
    public class ComboDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public decimal? Price { get; set; }
        //public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
    }

}
