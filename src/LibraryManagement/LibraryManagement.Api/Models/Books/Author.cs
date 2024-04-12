using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibraryManagement.Api.Models.Commons;

namespace LibraryManagement.Api.Models.Books
{
    public class Author
    {
        [Key]
        public int AuthorID { get; private set; }
        public string Biography { get; set; } = default!;
        public string FullName { get; set; } = default!;

        [ForeignKey("Country")]
        public int? NationalityCountryId { get; set; }
        public virtual Country? CountryInfo { get; set; }
    }
}
