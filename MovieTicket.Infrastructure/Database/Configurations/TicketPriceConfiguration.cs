using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class TicketPriceConfiguration : IEntityTypeConfiguration<TicketPrice>
    {
        public void Configure(EntityTypeBuilder<TicketPrice> builder)
        {
            builder.ToTable("TicketPrice");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CinemaTypes).WithMany(x => x.TicketPrices).HasForeignKey(x => x.CinemaTypeId);
            builder.HasOne(x => x.ScreenType).WithMany(x => x.TicketPrices).HasForeignKey(x => x.ScreenTypeId);
            builder.HasOne(x => x.SeatType).WithMany(x => x.TicketPrices).HasForeignKey(x => x.SeatTypeId);
            builder.HasOne(x => x.ScreeningDay).WithMany(x => x.TicketPrices).HasForeignKey(x => x.ScreeningDayId);
        }
    }
}