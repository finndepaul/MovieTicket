using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class ScreenTypeConfiguration : IEntityTypeConfiguration<ScreenType>
    {
        public void Configure(EntityTypeBuilder<ScreenType> builder)
        {
            builder.ToTable("ScreenType");
            builder.HasKey(x => x.Id);
        }
    }
}