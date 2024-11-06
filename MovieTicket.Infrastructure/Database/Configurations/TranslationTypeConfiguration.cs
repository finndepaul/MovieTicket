using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Database.Configurations
{
    internal class TranslationTypeConfiguration : IEntityTypeConfiguration<TranslationType>
    {
        public void Configure(EntityTypeBuilder<TranslationType> builder)
        {
            builder.ToTable("TranslationType");
            builder.HasKey(x => x.Id);
        }
    }
}