using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementTest.DataAccess.Dtos;

namespace EmployeeManagementTest.DataAccess.Interfaces
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();

        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);

    }
}
