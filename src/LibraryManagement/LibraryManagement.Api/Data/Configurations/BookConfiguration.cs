using LibraryManagement.Api.Models.Books;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Api.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookID);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13); 

            // Foreign Key configurations
            builder.HasOne(b => b.BookAuthor)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorID);

            builder.HasOne(b => b.BookGenre)
                   .WithMany(g => g.Books)
                   .HasForeignKey(b => b.GenreID);

            builder.HasOne(b => b.BookPublisher)
                   .WithMany(p => p.Books)
                   .HasForeignKey(b => b.PublisherID);

            // Other property configurations (optional)
            builder.Property(b => b.Description).HasMaxLength(300);
        }
    }
}
