using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cSharpWebApi.Data.Book.Dto;

namespace cSharpWebApi.Service.BookService
{
    public interface IBookService
    {
        Task<List<Data.Book.Book>> GetAllBooks();
        Task<Data.Book.Book?> GetSingleBook(int id);
        Task<Data.Book.Book?> UpdateBook(int id, UpdateBook updateBook);
        Task<List<Data.Book.Book>> CreateBook(CreateBook createBook);
        Task<ActionResult<IEnumerable<Data.Book.Book>>> DeleteBook(int id);
    }
}