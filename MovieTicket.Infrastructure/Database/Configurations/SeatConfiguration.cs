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
    internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cinema).WithMany(x=>x.Seats).HasForeignKey(x => x.CinemaId);
            builder.HasOne(x=>x.SeatType).WithMany(x=>x.Seats).HasForeignKey(x=>x.SeatTypeId);
        }
    }
}
