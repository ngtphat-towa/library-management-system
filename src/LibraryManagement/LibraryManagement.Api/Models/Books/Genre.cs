using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Api.Models.Books
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; } = default!;
        public string Description { get; set; } = default!;


    }
}
