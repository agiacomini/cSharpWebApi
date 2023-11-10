using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharpWebApi.Data.Department;
using cSharpWebApi.Data.Department.Dto;
using Microsoft.AspNetCore.Mvc;

namespace cSharpWebApi.Service.Department
{
    public interface IDepartmentService
    {
        Task<List<Data.Department.Department>> GetAllDepartments();
        Task<Data.Department.Department?> GetSingleDepartment(int id);
        Task<Data.Department.Department?> UpdateDepartment(int id, UpdateDepartment department);
        Task<List<Data.Department.Department>> CreateDepartment(CreateDepartment department);
        Task<ActionResult<IEnumerable<Data.Department.Department>>> DeleteDepartment(int id);
    }
}