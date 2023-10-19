using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Department;

namespace cSharpWebApi.Data.Employee
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public int? AddressId {get; set;}
        public Address.Address? Address {get; set;}
        public Department.Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}