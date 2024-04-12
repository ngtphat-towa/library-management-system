using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Api.Models.Books
{
    public class Genre
    {
        [Key]
        public int GenreID { get; private set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
