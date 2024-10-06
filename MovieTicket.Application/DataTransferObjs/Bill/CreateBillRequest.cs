﻿namespace MovieTicket.Application.DataTransferObjs.Bill
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