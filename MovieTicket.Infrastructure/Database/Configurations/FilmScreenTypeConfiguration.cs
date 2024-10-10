using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    public class FilmScreenTypeConfiguration : IEntityTypeConfiguration<FilmScreenType>
    {
        public void Configure(EntityTypeBuilder<FilmScreenType> builder)
        {
            builder.HasKey(x => new { x.ScreenTypeId, x.FilmId });
            builder.HasOne(x => x.ScreenType).WithMany(x => x.FilmScreenTypes).HasForeignKey(x => x.ScreenTypeId);
            builder.HasOne(x => x.Film).WithMany(x => x.FilmScreenTypes).HasForeignKey(x => x.FilmId);
        }
    }
}