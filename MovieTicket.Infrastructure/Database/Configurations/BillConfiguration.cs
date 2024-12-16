using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TotalMoney).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CreateTime).HasColumnType("date");
            builder.HasOne(x => x.Account).WithMany(x => x.Bills).HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.Coupon).WithMany(x => x.Bills).HasForeignKey(x => x.CouponId);
        }
    }
}