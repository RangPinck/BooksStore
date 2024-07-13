using BS.Core.Models;
using BS.DataAccess.Repositories;

namespace BS.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _booksRepository.GetBooks();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.CreateBook(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _booksRepository.UpdateBook(
                id: id,
                title: title,
                description: description,
                price: price
                );
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepository.DeleteBook(id);
        }
    }
}
