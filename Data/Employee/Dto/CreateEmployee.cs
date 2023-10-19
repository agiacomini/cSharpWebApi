using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Employee.Dto
{
    public class CreateEmployee
    {
        public int Id { get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public int? AddressId {get; set;}
        public int? DepatmentId {get; set;}
    }
}