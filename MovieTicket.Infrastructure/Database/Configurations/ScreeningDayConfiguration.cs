using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class ScreeningDayConfiguration : IEntityTypeConfiguration<ScreeningDay>
    {
        public void Configure(EntityTypeBuilder<ScreeningDay> builder)
        {
            builder.HasKey(x => x.Id);
          
        }
    }
}
