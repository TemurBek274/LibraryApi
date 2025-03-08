using eBook.Domain.Entities;
using eLibrary.Services;
using LibraryApi.Data;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("all-book")]

        public async Task<IActionResult> GetAllBook()
        {
            var books = await _bookService.GetBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}", Name = "byId-book")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookId(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("create-book")]

        public async Task<IActionResult> CreatedBook([FromBody] CreateBookDt bookDto)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishedYear = bookDto.PublishedYear,
                ISBN = bookDto.ISBN,
                Genre = bookDto.Genre,
                Price = bookDto.Price,


            };
            await _bookService.AddBook(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto bookDto)
        {
            var existingBook = await _bookService.GetBookId(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = bookDto.Title;
            existingBook.Author = bookDto.Author;
            existingBook.ISBN = bookDto.ISBN;
            existingBook.Price = bookDto.Price;
            existingBook.PublishedYear = bookDto.PublishedYear;
            existingBook.Genre = bookDto.Genre;

            await _bookService.UpdateBook(existingBook);
            return Ok(existingBook);
        }

    }
}
