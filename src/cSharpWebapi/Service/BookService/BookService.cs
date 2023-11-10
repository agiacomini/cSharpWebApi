using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data;
using cSharpWebApi.Data.AuthorBook;
using cSharpWebApi.Data.Book;
using cSharpWebApi.Data.Book.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace cSharpWebApi.Service.BookService
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _context;

        public BookService(DatabaseContext context)
        {
            _context = context;   
        }
        public async Task<List<Book>> CreateBook(CreateBook createBook)
        {
            var newBook = new Book()
            {
                Title = createBook.Title,
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            if (!createBook.Authors.IsNullOrEmpty())
            {
                foreach (var item in createBook.Authors)
                {
                    _context.AuthorBook.Add(new AuthorBook(){ AuthorId = item, BookId = newBook.Id});
                }
            }
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Book>>> DeleteBook(int id)
        {
            var bookToDelete = await _context.Books.Include(x => x.BookAuthors)
                                                   .FirstOrDefaultAsync(x => x.Id == id);
            if (bookToDelete is null)
                return null;
                
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.Include(x => x.BookAuthors)
                                            .ToListAsync();
            return books;
        }

        public async Task<Book?> GetSingleBook(int id)
        {
            var book = await _context.Books.Include(x => x.BookAuthors)
                                           .FirstOrDefaultAsync(x => x.Id == id);
            if (book is null)
                return null;
            return book;
        }

        public async Task<Book?> UpdateBook(int id, UpdateBook updateBook)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(x => x.Id == id);

            bookToUpdate.Title = !string.IsNullOrEmpty(updateBook.Title) ? updateBook.Title : bookToUpdate.Title;

            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();
            return bookToUpdate;
        }
    }
}