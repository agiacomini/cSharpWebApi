using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data;
using cSharpWebApi.Data.Department;
using cSharpWebApi.Service.Department;
using cSharpWebApi.Data.Department.Dto;

namespace cSharpWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(DatabaseContext context, IDepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FetchDepartment>>> GetDepartments()
        {
            List<Department> departments = await _departmentService.GetAllDepartments();
            List<FetchDepartment> fetchDepartmentsList = new List<FetchDepartment>();

            foreach (var department in departments)
            {
                fetchDepartmentsList.Add(DataUtils.PrepareFetchDepartment(department));
            }
            return fetchDepartmentsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FetchDepartment>> GetDepartment(int id)
        {
            if (!DepartmentExists(id))
                return NotFound("Department id " + id + " not found");

            var department = await _departmentService.GetSingleDepartment(id);
            return DataUtils.PrepareFetchDepartment(department);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> PutDepartment(int id, UpdateDepartment updateDepartment)
        {
            if (!DepartmentExists(id))
                return NotFound("Department id " + id + " not found");

            Department? result = await _departmentService.UpdateDepartment(id, updateDepartment);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FetchDepartment>>> PostDepartment(CreateDepartment createDepartment)
        {
            await _departmentService.CreateDepartment(createDepartment);
            return await GetDepartments();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<FetchDepartment>>> DeleteDepartment(int id)
        {
            if (!DepartmentExists(id))
                return NotFound("Department id " + id + " not found");

            await _departmentService.DeleteDepartment(id);
            return await GetDepartments();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}