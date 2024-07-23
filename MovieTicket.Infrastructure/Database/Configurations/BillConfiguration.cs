using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TotalMoney).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CreateTime).HasColumnType("date");
            builder.HasOne(x => x.Membership).WithMany(x=>x.Bills).HasForeignKey(x => x.MembershipId);
            builder.HasOne(x => x.Voucher).WithMany(x => x.Bills).HasForeignKey(x => x.VoucherId);
        }
    }
}
