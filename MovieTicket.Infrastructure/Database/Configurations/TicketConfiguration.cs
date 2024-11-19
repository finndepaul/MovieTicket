using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
	internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
	{
		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.ToTable("Ticket");
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Bill).WithMany(x => x.Tickets).HasForeignKey(x => x.BillId);
			builder.HasOne(x => x.Seat).WithMany(x => x.Tickets).HasForeignKey(x => x.SeatId);
			builder.HasOne(x => x.ShowTime).WithMany(x => x.Tickets).HasForeignKey(x => x.ShowTimeId);
			builder.HasOne(x => x.TicketPrice).WithMany(x => x.Ticket).HasForeignKey(x => x.TicketPriceId);
		}
	}
}