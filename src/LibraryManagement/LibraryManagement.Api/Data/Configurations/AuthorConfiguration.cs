using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Models.Commons;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Api.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorID);
            builder.Property(a => a.Biography).HasMaxLength(300);
            builder.Property(a => a.FullName).IsRequired();

            // Foreign Key configuration
            builder.HasOne(a => a.CountryInfo)
                   .WithMany(c => c.Authors)
                   .HasForeignKey(a => a.CountryInfoId);
        }
    }

}
