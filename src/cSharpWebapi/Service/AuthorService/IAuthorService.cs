using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Author;
using cSharpWebApi.Data.Author.Dto;
using Microsoft.AspNetCore.Mvc;

namespace cSharpWebApi.Service.AuthorService
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetSingleAuthor(int id);
        Task<Author?> UpdateAuthor(int id, UpdateAuthor author);
        Task<List<Author>> CreateAuthor(CreateAuthor author);
        Task<ActionResult<IEnumerable<Author>>> DeleteAuthor(int id);
    }
}