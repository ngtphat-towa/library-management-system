using LibraryManagement.Api.Data;
using LibraryManagement.Api.Models.Books;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public BookController(LMSDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.Include(b => b.BookAuthor)
                                        .Include(b => b.BookGenre)
                                        .Include(b => b.BookPublisher)
                                        .ToListAsync();
        }
    }
}
