using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

namespace PruebaCrud.Web.Controllers
{
    public class AddEmployeeController : Controller
    {
        private readonly INotyfService _toastNotification;
        private readonly IEmployeeService _employeeService;
        public AddEmployeeController(INotyfService toastNotification, IEmployeeService employeeService)
        {
            _toastNotification = toastNotification;
            _employeeService = employeeService; 
        }

        public IActionResult Index()
        {
            var employeeDto = new EmployeeDto();

            return View("../Employee/AddEmployee", employeeDto);
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeDto insertEmployeeDto)
        {
            _toastNotification.Success("You have successfully saved the data.");
            _employeeService.Insert(insertEmployeeDto);
            ModelState.Clear();
            var employeeDto = new EmployeeDto();
            return View("../Employee/AddEmployee", employeeDto);
        }
    }
}
