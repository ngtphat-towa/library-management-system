using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibraryManagement.Api.Models.Commons;

namespace LibraryManagement.Api.Models.Books
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        public string Title { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? AdditionalDetails { get; set; }

        // Book details
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; } = default!;

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; } = default!;

        [ForeignKey("Publisher")]
        public int? PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }

        public string? Language { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? CoverImagePath { get; set; }
        public int Pages { get; set; }
    }
}
