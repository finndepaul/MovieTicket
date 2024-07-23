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
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CinemaType).WithOne(x=>x.Cinema).HasForeignKey<Cinema>(x=>x.CinemaTypeId);
            builder.HasOne(x => x.CinemaCenter).WithMany(x=>x.Cinemas).HasForeignKey(x=>x.CinemaCenterId);
        }
    }
}
