using eBook.Domain.Entities;
using LibraryApi.Data;
using LibraryApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookId(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book updateBook)
        {
           _context.Books.Update(updateBook);
           await _context.SaveChangesAsync();
            return updateBook;
        }

        public async Task<Book> DeleteBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

    }
}
