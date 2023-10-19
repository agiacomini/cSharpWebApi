using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Book.Dto;

namespace cSharpWebApi.Data.AuthorBook.Dto
{
    public class FetchAuthorBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public required FetchBook Book { get; set; }
    }
}