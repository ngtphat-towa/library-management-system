using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibraryManagement.Api.Models.Commons;

namespace LibraryManagement.Api.Models.Books
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = default!;

        [ForeignKey("Country")]
        public int? CountryInfoId { get; set; }
        public virtual Country? CountryInfo { get; set; }
    }
}
