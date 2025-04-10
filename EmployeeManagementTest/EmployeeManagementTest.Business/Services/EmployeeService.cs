using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using EmployeeManagementTest.Business.Interfaces;
using EmployeeManagementTest.Business.Models;
using EmployeeManagementTest.DataAccess.Interfaces;

namespace EmployeeManagementTest.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeApiClient _apiClient;

        public EmployeeService(IEmployeeApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var dtoList = await _apiClient.GetAllEmployeesAsync();

            return dtoList.Select(d => new Employee
            {
                Id = d.id,
                EmployeeName = d.employee_name,
                EmployeeAge = d.employee_age,
                Salary = d.employee_salary,
                ProfileImage = d.profile_image
            }).ToList();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var dto = await _apiClient.GetEmployeeByIdAsync(id);

            if (dto == null) return null;

            return new Employee
            {
                Id = dto.id,
                EmployeeName = dto.employee_name,
                EmployeeAge = dto.employee_age,
                Salary = dto.employee_salary,
                ProfileImage = dto.profile_image
            };
        }
    }

}

