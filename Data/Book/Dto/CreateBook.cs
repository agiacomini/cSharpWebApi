using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Book.Dto
{
    public class CreateBook
    {
        public string Title { get; set; } = string.Empty;
        public List<int> Authors { get; set; } = new List<int>();
    }
}