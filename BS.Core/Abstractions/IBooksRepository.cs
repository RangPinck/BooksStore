using BS.Core.Models;

namespace BS.DataAccess.Repositories
{
    public interface IBooksRepository
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<IEnumerable<Book>> GetBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}