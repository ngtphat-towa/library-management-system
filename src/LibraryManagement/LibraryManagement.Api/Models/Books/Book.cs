using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Api.Models.Books
{
    public class Book
    {
        [Key]
        public int BookID { get; private set; }
        public string Title { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? AdditionalDetails { get; set; }

        // Book details
        [ForeignKey("Author")]
        public int? AuthorID { get; set; }
        public virtual Author? BookAuthor { get; set; }

        [ForeignKey("Genre")]
        public int? GenreID { get; set; }
        public virtual Genre? BookGenre { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherID { get; set; }
        public virtual Publisher? BookPublisher { get; set; }


        public DateTime? PublicationDate { get; set; }
        public string? BookImagePath { get; set; }
    }
}
