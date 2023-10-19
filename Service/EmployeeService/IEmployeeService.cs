using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Employee;
using cSharpWebApi.Data.Employee.Dto;
using cSharpWebApi.Data.Author.Dto;
using Microsoft.AspNetCore.Mvc;

namespace cSharpWebApi.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetSingleEmployee(int id);
        Task<Employee?> UpdateEmployee(int id, UpdateEmployee employee);
        Task<List<Employee>> CreateEmployee(CreateEmployee employee);
        Task<ActionResult<IEnumerable<Employee>>> DeleteEmployee(int id);
    }
}