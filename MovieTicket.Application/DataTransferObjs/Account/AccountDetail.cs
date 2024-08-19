using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Account
{
    public class AccountDetail
    {
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public AccountRole? Role { get; set; }
        public AccountStatus? Status { get; set; }
    }
}
