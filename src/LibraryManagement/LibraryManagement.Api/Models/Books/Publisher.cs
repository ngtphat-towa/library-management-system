using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibraryManagement.Api.Models.Commons;

namespace LibraryManagement.Api.Models.Books
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = default!;

        [ForeignKey("Country")]
        public int? CountryInfoId { get; set; }
        public virtual Country? CountryInfo { get; set; }
        public virtual IEnumerable<Book> Books { get; set; } = default!;

    }
}
