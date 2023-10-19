using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using cSharpWebApi.Data.Employee;
using cSharpWebApi.Data.Author;

namespace cSharpWebApi.Data.Address
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }
        public string? State {get; set;}
        public string Country {get; set;} = string.Empty;
        public string ZipCode {get; set;} = string.Empty;
        [JsonIgnore]
        public Author.Author? AuthorAddress { get; set; }
        [JsonIgnore]
        public Employee.Employee? EmployeeAddress { get; set; }
    }
}