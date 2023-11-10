using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.AuthorBook.Dto;

namespace cSharpWebApi.Data.Author.Dto
{
    public class FetchAuthor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public ICollection<FetchAuthorBook>? AuthorBooks { get; set; }

    }
}