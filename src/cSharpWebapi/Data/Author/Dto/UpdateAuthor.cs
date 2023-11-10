using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.AuthorBook.Dto;

namespace cSharpWebApi.Data.Author.Dto
{
    public class UpdateAuthor
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? AddressId { get; set; }
        public int[]? BookId { get; set; }
    }
}