using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class FilmTranslationTypeConfiguration : IEntityTypeConfiguration<FilmTranslationType>
    {
        public void Configure(EntityTypeBuilder<FilmTranslationType> builder)
        {
            builder.ToTable("FilmTranslationType");
            builder.HasKey(x => new { x.TranslationTypeId, x.FilmId });
            builder.HasOne(x => x.Film).WithMany(x => x.FilmTranslationTypes).HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.TranslationType).WithMany(x => x.FilmTranslationTypes).HasForeignKey(x => x.TranslationTypeId);
        }
    }
}