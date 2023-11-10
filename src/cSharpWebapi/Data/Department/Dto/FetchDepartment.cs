using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Employee.Dto;

namespace cSharpWebApi.Data.Department.Dto
{
    public class FetchDepartment
    {
        public int Id { get; set; }
        public string NameDepartment { get; set; } = string.Empty;
        public List<FetchEmployee> Employees { get; set; } = new List<FetchEmployee>();
    }
}