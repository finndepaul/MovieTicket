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
    public class CinemaTypeConfiguration : IEntityTypeConfiguration<CinemaType>
    {
        public void Configure(EntityTypeBuilder<CinemaType> builder)
        {
            builder.HasKey(x => x.Id);
       
        }
    }
}
