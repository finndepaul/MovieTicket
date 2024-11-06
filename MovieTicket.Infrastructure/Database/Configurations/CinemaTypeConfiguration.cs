using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class CinemaTypeConfiguration : IEntityTypeConfiguration<CinemaType>
    {
        public void Configure(EntityTypeBuilder<CinemaType> builder)
        {
            builder.ToTable("CinemaType");
            builder.HasKey(x => x.Id);
        }
    }
}