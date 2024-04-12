using LibraryManagement.Api.Models.Books;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Api.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13);

            // Foreign Key configurations
            builder.HasOne(b => b.Author)
                   .WithMany()
                   .HasForeignKey(b => b.AuthorId);

            builder.HasOne(b => b.Genre)
                   .WithMany()
                   .HasForeignKey(b => b.GenreId);

            builder.HasOne(b => b.Publisher)
                   .WithMany()
                   .HasForeignKey(b => b.PublisherId);

            // Other property configurations (optional)
            builder.Property(b => b.Description).HasMaxLength(300);
        }
    }
}
