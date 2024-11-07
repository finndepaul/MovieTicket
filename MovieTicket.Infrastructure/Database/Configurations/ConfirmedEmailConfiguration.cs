using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class ConfirmedEmailConfiguration : IEntityTypeConfiguration<ConfirmedEmail>
    {
        public void Configure(EntityTypeBuilder<ConfirmedEmail> builder)
        {
            builder.ToTable("ConfirmedEmail");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Account).WithMany(x => x.ConfirmedEmails).HasForeignKey(x => x.AccountId);
        }
    }
}