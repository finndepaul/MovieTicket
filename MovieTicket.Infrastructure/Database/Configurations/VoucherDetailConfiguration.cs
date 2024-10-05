using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class VoucherDetailConfiguration : IEntityTypeConfiguration<VoucherDetail>
    {
        public void Configure(EntityTypeBuilder<VoucherDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Voucher).WithMany(x => x.VoucherDetails).HasForeignKey(x => x.VoucherId);
        }
    }
}