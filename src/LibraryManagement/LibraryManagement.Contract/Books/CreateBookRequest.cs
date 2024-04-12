namespace LibraryManagement.Contract.Books;

public record CreateBookRequest
{
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? AdditionalDetails { get; set; }

    public int AuthorId { get; set; }
    public int GenreId { get; set; }
    public int? PublisherId { get; set; }

    public int Pages { get; set; }
    public string Language { get; set; } = default!;
    public DateTime? PublicationDate { get; set; }
    public string? CoverImagePath { get; set; }
}