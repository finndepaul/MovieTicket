﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
	public class CheckOutSuccessRequest
	{
		public Guid BillId { get; set; }
		public int? MembershipPoint { get; set; }
	}
}