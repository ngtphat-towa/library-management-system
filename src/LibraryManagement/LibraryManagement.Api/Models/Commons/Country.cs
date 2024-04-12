using System.ComponentModel.DataAnnotations;

using LibraryManagement.Api.Models.Books;

namespace LibraryManagement.Api.Models.Commons
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; } = default!;

        public virtual IEnumerable<Author> Authors { get; set; } = default!;
        public virtual IEnumerable<Publisher> Publishers { get; set; } = default!;
        public virtual IEnumerable<Book> Books { get; set; } = default!;
    }
}
