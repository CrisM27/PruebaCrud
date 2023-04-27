using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class EditEmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly INotyfService _notyfService;

        public EditEmployeeController(IEmployeeService employeeService,INotyfService notyfService)
        {
            _employeeService = employeeService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return View("../Employee/EditEmployee",employee);
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeDto employeeDto)
        {
            _employeeService.Update(employeeDto);
            _notyfService.Success("Changes has been saved.");
            return View("../Employee/EditEmployee");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeDto employeeDto)
        {
            _employeeService.DeleteEmployee(employeeDto);
            _notyfService.Success("Changes has been saved.");
            var employeeList = _employeeService.GetAll();
            return View("../Employee/Index", employeeList);
        }
    }
}
