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
    public class ConfirmedEmailConfiguration : IEntityTypeConfiguration<ConfirmedEmail>
    {
        public void Configure(EntityTypeBuilder<ConfirmedEmail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Account).WithMany(x => x.ConfirmedEmails).HasForeignKey(x => x.AccountId);
        }
    }
}
