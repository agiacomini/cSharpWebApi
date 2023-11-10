using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Author;
using cSharpWebApi.Data.AuthorBook;
using cSharpWebApi.Data.Author.Dto;
using cSharpWebApi.Data.AuthorBook.Dto;
using cSharpWebApi.Data.Book.Dto;
using cSharpWebApi.Service.AuthorService;

namespace cSharpWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IAuthorService _authorService;

        public AuthorController(DatabaseContext context, IAuthorService authorService)
        {
            _context = context;

            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FetchAuthor>>> GetAuthors()
        {
            List<Author> authors = await _authorService.GetAllAuthors();
            List<FetchAuthor> fetchAuthorsList = new List<FetchAuthor>();
            foreach (var author in authors)
            {
                fetchAuthorsList.Add(DataUtils.PrepareFetchAuthor(author));
            }
            return fetchAuthorsList;
        }

        // [HttpGet]
        // [Route("{id}")]
        // Equals to ...
        [HttpGet("{id}")]
        public async Task<ActionResult<FetchAuthor>> GetAuthor(int id)
        {
            if (!AuthorExists(id))
                return NotFound("Author id " + id + " not found");

            var author = await _authorService.GetSingleAuthor(id);
            return DataUtils.PrepareFetchAuthor(author); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FetchAuthor>> PutAuthor(int id, UpdateAuthor author)
        {
            if (!AuthorExists(id))
                return NotFound("Author id " + id + " not found");

            var result = await _authorService.UpdateAuthor(id, author);
            FetchAuthor fetchAuthor = DataUtils.PrepareFetchAuthor(result);
            return fetchAuthor;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FetchAuthor>>> PostAuthor(CreateAuthor author)
        {
            List<Author> authorsResult = await _authorService.CreateAuthor(author);
            return await GetAuthors();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<FetchAuthor>>> DeleteAuthor(int id)
        {   
            if (!AuthorExists(id))
                return NotFound("Author id " + id + " not found");

            var result = await _authorService.DeleteAuthor(id);
            return await GetAuthors();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}