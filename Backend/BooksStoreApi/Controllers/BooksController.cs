using BooksStore.API.Contracts;
using BS.Application.Services;
using BS.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksResponse>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();
            var responce = books.Select(
                b => new BooksResponse(
                    Id: b.Id,
                    Title: b.Title,
                    Description: b.Description,
                    Price: b.Price)).ToList();

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                id: new Guid(),
                title: request.Title,
                description: request.Description,
                price: request.Price
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

           var bookId = await _booksService.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksService.UpdateBook(
                id:id,
                title: request.Title,
                description: request.Description,
                price: request.Price
                );

            return Ok(bookId);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _booksService.DeleteBook(id: id);

            return Ok(bookId);
        }

    }
}
