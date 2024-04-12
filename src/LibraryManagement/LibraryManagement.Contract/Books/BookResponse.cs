namespace LibraryManagement.Contract.Books;

public record BookResponse
{
    public required Guid BookId { get; set; }
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public required string Description { get; set; }
    public string? AdditionalDetails { get; set; }
    public int? AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public int? GenreId { get; set; }
    public string? GenreName { get; set; }
    public int? PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? CoverImagePath { get; set; }
    public string? Language { get; set; }
    public int Pages { get; set; }
}