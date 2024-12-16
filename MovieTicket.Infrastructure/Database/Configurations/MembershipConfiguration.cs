using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("Membership");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Account).WithOne(x => x.Membership).HasForeignKey<Membership>(x => x.AccountId);
        }
    }
}