﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Combo
{
    public class CreateComboRequest
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }
    }

}