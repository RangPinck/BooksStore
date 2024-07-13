using BS.Core.Models;
using BS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BS.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksStoreDbContext _context;

        public BooksRepository(BooksStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities.Select(
                b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book).ToList();

            return books;
        }

        public async Task<Guid> CreateBook(Book book)
        {
            var bookEntity = new BookEntity()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(
                    s => s.SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));

            return id;
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
