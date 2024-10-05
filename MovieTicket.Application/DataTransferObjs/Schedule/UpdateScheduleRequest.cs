﻿using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Schedule
{
    public class UpdateScheduleRequest
    {
        public Guid? FilmId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ScheduleType? Type { get; set; }

        //public ScheduleStatus? Status { get; set; }
    }
}