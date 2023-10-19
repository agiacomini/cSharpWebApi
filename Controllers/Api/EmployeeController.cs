using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Employee.Dto;
using cSharpWebApi.Data.Employee;
using cSharpWebApi.Service.EmployeeService;

namespace cSharpWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(DatabaseContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FetchEmployee>>> GetEmployees()
        {
            List<Employee> employees = await _employeeService.GetAllEmployees();
            List<FetchEmployee> fetchEmployeesList = new List<FetchEmployee>();
            foreach (var employee in employees)
            {
                fetchEmployeesList.Add(DataUtils.PrepareFetchEmployee(employee));
            }
            return fetchEmployeesList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FetchEmployee>> GetEmployee(int id)
        {
          if (!EmployeeExists(id))
                return NotFound("Employee id " + id + " not found");

            var employee = await _employeeService.GetSingleEmployee(id);
            return DataUtils.PrepareFetchEmployee(employee); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FetchEmployee>> PutEmployee(int id, UpdateEmployee employee)
        {
            if (!EmployeeExists(id))
                return NotFound("Employee id " + id + " not found");

            Employee? result = await _employeeService.UpdateEmployee(id, employee);
            FetchEmployee fetchEmployee = DataUtils.PrepareFetchEmployee(result);
            return fetchEmployee;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FetchEmployee>>> PostEmployee(CreateEmployee createEmployee)
        {
            List<Employee> employeesResult = await _employeeService.CreateEmployee(createEmployee);
            return await GetEmployees();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<FetchEmployee>>> DeleteEmployee(int id)
        {
            if (!EmployeeExists(id))
                return NotFound("Employee id " + id + " not found");

            await _employeeService.DeleteEmployee(id);
            return await GetEmployees();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
