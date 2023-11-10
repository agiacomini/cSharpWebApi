using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpWebApi.Data.Employee.Dto
{
    public class UpdateEmployee
    {
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public int? AddressId {get; set;}
        public int? DepartmentId {get; set;}
    }
}