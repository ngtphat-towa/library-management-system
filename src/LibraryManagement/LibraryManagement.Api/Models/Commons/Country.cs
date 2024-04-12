using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Api.Models.Commons
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; } = default!;
    }
}
