namespace BS.DataAccess.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0.0M;
    }
}
