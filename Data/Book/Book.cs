using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Book
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        [NotNull]
        public string Title { get; set; } = string.Empty;
        public ICollection<AuthorBook.AuthorBook> BookAuthors { get; set; } = new List<AuthorBook.AuthorBook>();
    }
}