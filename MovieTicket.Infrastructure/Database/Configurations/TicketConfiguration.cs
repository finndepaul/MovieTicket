﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.Bill).WithMany(x=>x.Tickets).HasForeignKey(x => x.BillId);
                builder.HasOne(x => x.Seat).WithMany(x => x.Tickets).HasForeignKey(x => x.SeatId);
            builder.HasOne(x => x.ShowTime).WithMany(x => x.Tickets).HasForeignKey(x => x.ShowTimeId);
            builder.HasOne(x=>x.TicketPrice).WithOne(x=>x.Ticket).HasForeignKey<Ticket>(x=>x.TicketPriceId);
            builder.HasOne(x => x.CinemaCenter).WithMany(x => x.Tickets).HasForeignKey(x => x.CinemaCenterId);

            }
    }
}
