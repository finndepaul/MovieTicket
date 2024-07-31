using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Account
{
    public class ForgotPasswordRequest
    {
        public Guid AccountId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPW { get; set; }
    }
}
