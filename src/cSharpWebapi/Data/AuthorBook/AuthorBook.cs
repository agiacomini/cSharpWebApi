using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.AuthorBook
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author.Author? Author { get; set; }
        public int BookId { get; set; }
        public Book.Book? Book { get; set; }
    }
}