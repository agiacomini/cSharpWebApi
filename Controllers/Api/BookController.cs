using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Book;
using cSharpWebApi.Data.Book.Dto;
using cSharpWebApi.Service.BookService;

namespace cSharpWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IBookService _bookService;

        public BookController(DatabaseContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FetchBook>>> GetBooks()
        {
            List<Book> books = await _bookService.GetAllBooks();
            List<FetchBook> fetchBooksList = new List<FetchBook>();

            foreach (var book in books)
            {
                fetchBooksList.Add(DataUtils.PrepareFetchBook(book));
            }
            return fetchBooksList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FetchBook>> GetBook(int id)
        {
          if (!BookExists(id))
                return NotFound("Book id " + id + " not found");

            var book = await _bookService.GetSingleBook(id);
            return DataUtils.PrepareFetchBook(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, UpdateBook updateBook)
        {
            if (!BookExists(id))
                return NotFound("Book id " + id + " not found");

            return await _bookService.UpdateBook(id, updateBook);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FetchBook>>> PostBook(CreateBook createBook)
        {
            await _bookService.CreateBook(createBook);
            return await GetBooks();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<FetchBook>>> DeleteBook(int id)
        {
            if (!BookExists(id))
                return NotFound("Book id " + id + " not found");

            await _bookService.DeleteBook(id);
            return await GetBooks();
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}