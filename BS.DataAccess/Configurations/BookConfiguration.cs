using BS.Core.Models;
using BS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(Book.TITLE_LENGTH_MAX)
                .IsRequired();

            builder.Property(x => x.Description);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
