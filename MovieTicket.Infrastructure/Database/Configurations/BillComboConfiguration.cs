using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class BillComboConfiguration : IEntityTypeConfiguration<BillCombo>
    {
        public void Configure(EntityTypeBuilder<BillCombo> builder)
        {
            builder.HasKey(x => new { x.ComboId, x.BillId });
            builder.HasOne(x => x.Bill).WithMany(x => x.BillCombos).HasForeignKey(x => x.BillId);
            builder.HasOne(x => x.Combo).WithMany(x => x.BillCombos).HasForeignKey(x => x.ComboId);
        }
    }
}