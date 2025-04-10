using System.Collections.Generic;
using System.Threading.Tasks;

using EmployeeManagementTest.Business.Models;

namespace EmployeeManagementTest.Business.Interfaces

{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
    }

}
