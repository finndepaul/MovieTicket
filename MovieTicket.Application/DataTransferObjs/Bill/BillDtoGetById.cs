﻿using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Bill
{
    public class BillDtoGetById
    {
        public Guid Id { get; set; }
        //public Guid? MembershipId { get; set; }

        //public Guid? VoucherId { get; set; }
        public decimal? TotalMoney { get; set; }

        public DateTime? CreateTime { get; set; }

        public string? BarCode { get; set; }

        public BillStatus? Status { get; set; }
        public List<ComboDto>? Combos { get; set; } = new List<ComboDto>();
    }
}