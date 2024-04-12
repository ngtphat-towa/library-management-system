using LibraryManagement.Api.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Api.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.GenreId);
            builder.Property(g => g.GenreName).IsRequired();
            builder.Property(g => g.Description).HasMaxLength(40);
        }
    }
}
