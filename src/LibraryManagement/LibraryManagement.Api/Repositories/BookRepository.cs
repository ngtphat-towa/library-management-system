using System.Linq.Expressions;

using LibraryManagement.Api.Data;
using LibraryManagement.Api.Models.Books;
using LibraryManagement.Api.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Book entity)
        {
            var result = await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Book entity)
        {
            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            return _dbContext.Books
                    .AsSplitQuery()
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                  .Where(expression);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result = await _dbContext.Books
                .AsSplitQuery()
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .ToListAsync();
            return result;
        }

        public async Task Update(Book entity)
        {
            _dbContext.Books.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
