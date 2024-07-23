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
    public class FilmTranslationTypeConfiguration : IEntityTypeConfiguration<FilmTranslationType>
    {
        public void Configure(EntityTypeBuilder<FilmTranslationType> builder)
        {
            builder.HasKey(x => new { x.TranslationTypeId, x.FilmId });
            builder.HasOne(x => x.Film).WithMany(x => x.FilmTranslationTypes).HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.TranslationType).WithMany(x => x.FilmTranslationTypes).HasForeignKey(x => x.TranslationTypeId);


        }
    }
}
