using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Repositories.Base;
using LibraryManagement.Contract.Books;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/book
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetAll();
                return Ok(books.Select(FromBookEntity));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/book/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookRepository.FindByCondition(b => b.BookId == id).FirstOrDefaultAsync();

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }

                return Ok(FromBookEntity(book));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookRequest request)
        {
            try
            {
                // TODO: add cloud services or local upload controller
                var newEntity = new Book
                {
                    Title = request.Title,
                    ISBN = request.ISBN,
                    Description = request.Description,
                    AdditionalDetails = request.AdditionalDetails,
                    AuthorId = request.AuthorId,
                    GenreId = request.GenreId,
                    PublisherId = request.PublisherId,
                    Pages = request.Pages,
                    PublicationDate = request.PublicationDate,
                    CoverImagePath = request.CoverImagePath,
                };
                await _bookRepository.Add(newEntity);
                return CreatedAtAction(nameof(GetBookById), new { id = newEntity.BookId }, request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookRequest request)
        {
            try
            {
                var existingBook = await _bookRepository.FindByCondition(b => b.BookId == id).FirstOrDefaultAsync();

                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }

                // Update properties of existingBook based on request
                existingBook.Title = request.Title;
                existingBook.ISBN = request.ISBN;
                existingBook.Description = request.Description;
                existingBook.AdditionalDetails = request.AdditionalDetails;

                existingBook.AuthorId = request.AuthorId;
                existingBook.GenreId = request.GenreId;
                existingBook.PublisherId = request.PublisherId;
                
                existingBook.Language = request.Language;
                existingBook.Pages = request.Pages;
                existingBook.PublicationDate = request.PublicationDate;
                existingBook.CoverImagePath = request.CoverImagePath;

                await _bookRepository.Update(existingBook);

                return Ok(FromBookEntity(existingBook));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                var existingBook = await _bookRepository.FindByCondition(b => b.BookId == id).FirstOrDefaultAsync();

                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }

                await _bookRepository.Delete(existingBook);

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private static BookResponse FromBookEntity(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            return new BookResponse
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                AdditionalDetails = book.AdditionalDetails,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.FullName,
                GenreId = book.GenreId,
                GenreName = book.Genre?.GenreName,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher?.PublisherName,
                PublicationDate = book.PublicationDate,
                CoverImagePath = book.CoverImagePath,
                Pages = book.Pages,
                Language = book.Language
            };
        }
    }
}
