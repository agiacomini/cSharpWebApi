using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Author.Dto;

namespace cSharpWebApi.Data.Book.Dto
{
    public class FetchBook
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
        // public List<FetchAuthor> Authors { get; set; } = new List<FetchAuthor>();
        public List<int> Authors { get; set; } = new List<int>();
    }
}