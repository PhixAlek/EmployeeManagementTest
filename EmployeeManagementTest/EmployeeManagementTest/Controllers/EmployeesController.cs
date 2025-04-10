using Microsoft.AspNetCore.Mvc;
using EmployeeManagementTest.Business.Interfaces;
using EmployeeManagementTest.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }
    }

}
