using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Models.Commons;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Api.Data.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.PublisherId);
            builder.Property(p => p.PublisherName).IsRequired();

  
            builder.HasOne(p => p.CountryInfo)
                   .WithMany(c => c.Publishers)
                   .HasForeignKey(p => p.CountryInfoId);
        }
    }
}
