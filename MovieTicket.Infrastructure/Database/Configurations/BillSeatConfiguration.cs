using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class BillSeatConfiguration : IEntityTypeConfiguration<BillSeat>
    {
        public void Configure(EntityTypeBuilder<BillSeat> builder)
        {
            builder.HasKey(x => new { x.SeatId, x.BillId });
            builder.HasOne(x => x.Bill)
                .WithMany(x => x.BillSeats)
                .HasForeignKey(x => x.BillId);
            builder.HasOne(x => x.Seat).WithMany(x => x.BillSeats).HasForeignKey(x => x.SeatId);
        }
    }
}
