using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Film).WithMany(x => x.Schedules).HasForeignKey(x => x.FilmId);
        }
    }
}