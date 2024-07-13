using BS.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BS.DataAccess
{
    public class BooksStoreDbContext : DbContext
    {
        public BooksStoreDbContext(DbContextOptions<BooksStoreDbContext> options) : base(options)
        {}

        public DbSet<BookEntity> Books { get; set; }
    }
}
