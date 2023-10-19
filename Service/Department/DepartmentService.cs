using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Department;
using cSharpWebApi.Data.Department.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cSharpWebApi.Service.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DatabaseContext _context;

        public DepartmentService(DatabaseContext context)
        {
            _context = context;   
        }
        public async Task<List<Data.Department.Department>> CreateDepartment(CreateDepartment createDepartment)
        {
            var newDepartment = new Data.Department.Department()
            {
                NameDepartment = createDepartment.NameDepartment,
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return await _context.Departments.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Data.Department.Department>>> DeleteDepartment(int id)
        {
            var departmentToDelete = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (departmentToDelete is null)
                return null;
                
            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();

            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Data.Department.Department>> GetAllDepartments()
        {
            var departments = await _context.Departments.Include(x => x.Employees).ToListAsync();
            return departments;
        }

        public async Task<Data.Department.Department?> GetSingleDepartment(int id)
        {
            var department = await _context.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
                return null;
            return department;
        }

        public async Task<Data.Department.Department?> UpdateDepartment(int id, UpdateDepartment updateDepartment)
        {
            var departmentToUpdate = _context.Departments.FirstOrDefault(x => x.Id == id);

            departmentToUpdate.NameDepartment = !string.IsNullOrEmpty(updateDepartment.NameDepartment) ? updateDepartment.NameDepartment : departmentToUpdate.NameDepartment;

            _context.Departments.Update(departmentToUpdate);
            await _context.SaveChangesAsync();
            return departmentToUpdate;
        }
    }
}