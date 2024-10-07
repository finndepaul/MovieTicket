using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entitis;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class ScreeningDayConfiguration : IEntityTypeConfiguration<ScreeningDay>
    {
        public void Configure(EntityTypeBuilder<ScreeningDay> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}