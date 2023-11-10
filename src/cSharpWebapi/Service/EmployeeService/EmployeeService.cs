using cSharpWebApi.Data;
using cSharpWebApi.Data.Employee;
using cSharpWebApi.Data.Employee.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cSharpWebApi.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DatabaseContext _context;

        public EmployeeService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> CreateEmployee(CreateEmployee createEmployee)
        {
            var newEmployee = new Employee()
            {
                FirstName = createEmployee.FirstName,
                LastName = createEmployee.LastName,
                AddressId = createEmployee.AddressId,
                DepartmentId = createEmployee.DepatmentId
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Employee>>> DeleteEmployee(int id)
        {
            var employeeToDelete = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employeeToDelete is null)
                return null;
                
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.Include(x => x.Address).ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee is null)
                return null;
            return employee;
        }

        public async Task<Employee?> UpdateEmployee(int id, UpdateEmployee employee)
        {
            var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.Id == id);

            employeeToUpdate.FirstName = !string.IsNullOrEmpty(employee.FirstName) ? employee.FirstName : employeeToUpdate.FirstName;
            employeeToUpdate.LastName = employee.LastName != null ? employee.LastName : employeeToUpdate.LastName;
            employeeToUpdate.AddressId = (int)(employee.AddressId != null ? employee.AddressId : employeeToUpdate.AddressId);
            employeeToUpdate.DepartmentId = (int)(employee.DepartmentId != null ? employee.DepartmentId : employeeToUpdate.DepartmentId);

             _context.Employees.Update(employeeToUpdate);
            await _context.SaveChangesAsync();
            return employeeToUpdate;
        }
    }
}