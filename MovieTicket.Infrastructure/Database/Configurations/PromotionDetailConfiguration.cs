using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class PromotionDetailConfiguration : IEntityTypeConfiguration<PromotionDetail>
    {
        public void Configure(EntityTypeBuilder<PromotionDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Promotion).WithMany(x => x.PromotionDetails).HasForeignKey(x => x.PromotionId);
        }
    }
}