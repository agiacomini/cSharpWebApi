using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Employee;

namespace cSharpWebApi.Data.Department
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string NameDepartment { get; set; } = string.Empty;
        public List<Employee.Employee>? Employees { get; set; }
    }
}