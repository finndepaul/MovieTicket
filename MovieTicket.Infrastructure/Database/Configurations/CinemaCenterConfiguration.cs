using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class CinemaCenterConfiguration : IEntityTypeConfiguration<CinemaCenter>
    {
        public void Configure(EntityTypeBuilder<CinemaCenter> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}