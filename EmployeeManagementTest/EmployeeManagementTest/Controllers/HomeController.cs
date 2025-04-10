using EmployeeManagementTest.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("")]
public class HomeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public HomeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // Página principal (formulario de búsqueda)
    [HttpGet("")]
    public IActionResult Index(int? id)
    {
        if (id.HasValue)
        {
            return Redirect($"/employee/{id.Value}");
        }

        return View(); // Views/Home/Index.cshtml
    }

    // Listado de todos los empleados
    [HttpGet("employees")]
    public async Task<IActionResult> Employees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return View("AllEmployees", employees);
    }

    // Detalle de empleado
    [HttpGet("employee/{id}")]
    public async Task<IActionResult> EmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return Redirect("/notfound");
        }

        return View("Details", employee);
    }

    // Vista si no se encuentra el empleado
    [HttpGet("notfound")]
    public IActionResult NotFound()
    {
        return View();
    }

    // Nueva acción para búsqueda desde AllEmployees.cshtml
    [HttpGet("search")]
    public async Task<IActionResult> Search(int? id)
    {
        if (!id.HasValue)
        {
            return RedirectToAction("Employees");
        }

        var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
        if (employee == null)
        {
            return Redirect("/notfound");
        }

        return View("Details", employee);
    }
}
