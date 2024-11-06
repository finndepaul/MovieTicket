using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
    public class UpdateCheckRequest
    {
        public Guid BillId { get; set; }
        public Guid ShowTimeId { get; set; }
        public Guid CinemaCenterId { get; set; }
        public List<Guid>? LstComboId { get; set; }
        public Guid? VoucherId { get; set; }
    }
}