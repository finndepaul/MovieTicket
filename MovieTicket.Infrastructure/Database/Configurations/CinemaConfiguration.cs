using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CinemaType).WithMany(x => x.Cinema).HasForeignKey(x => x.CinemaTypeId);
            builder.HasOne(x => x.CinemaCenter).WithMany(x => x.Cinemas).HasForeignKey(x => x.CinemaCenterId);
        }
    }
}