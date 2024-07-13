namespace BS.Core.Models
{
    public class Book
    {
        public const int TITLE_LENGTH_MAX = 250;

        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; } = 0.0M;

        public static (Book Book, string error) Create(Guid id, string title, string description, decimal price = 0.0M)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Count() > TITLE_LENGTH_MAX)
            {
                error = "Title is empty or biggest 250 symbols";
            }

            if (price < 0.0M)
            {
                error = "Price is lowely 0";
            }

            var book = new Book(id, title, description, price); 
        
            return (book, error);
        }
    }
}
