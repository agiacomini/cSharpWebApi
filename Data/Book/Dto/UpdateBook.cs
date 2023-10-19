using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Book.Dto
{
    public class UpdateBook
    {
        public string Title { get; set; } = string.Empty;
        public ICollection<AuthorBook.AuthorBook> BookAuthors { get; set; } = new List<AuthorBook.AuthorBook>();
    }
}