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
    internal class ShowTimeConfiguration : IEntityTypeConfiguration<ShowTime>
    {
        public void Configure(EntityTypeBuilder<ShowTime> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ScreenType).WithMany(x => x.ShowTime).HasForeignKey(x => x.ScreenTypeId);
            builder.HasOne(x=>x.Cinema).WithMany(x=>x.ShowTimes).HasForeignKey(x=>x.CinemaId);
            builder.HasOne(x=>x.CinemaCenter).WithMany(x=>x.ShowTimes).HasForeignKey(x=>x.CinemaCenterId);
            builder.HasOne(x=>x.Film).WithMany(x=>x.ShowTimes).HasForeignKey(x=>x.FilmId);
            builder.HasOne(x=>x.Schedule).WithMany(x=>x.ShowTimes).HasForeignKey(x=>x.ScheduleId);
            builder.HasOne(x=>x.TranslationType).WithMany(x=>x.ShowTime).HasForeignKey(x=>x.TranslationTypeId);
            
        }
    }
}
