using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using cSharpWebApi.Data.Address;
using cSharpWebApi.Data.AuthorBook;

namespace cSharpWebApi.Data.Author
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public int AddressId {get; set;}
        [JsonIgnore]
        public Address.Address Address {get; set;}
        public ICollection<AuthorBook.AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook.AuthorBook>();
    }
}