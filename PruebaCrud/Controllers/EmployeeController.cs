using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

namespace PruebaCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly INotyfService _toastNotification;


        public EmployeeController(IEmployeeService service, IEmployeeTypeService employeeTypeService, INotyfService toastNotification)
        {
            _employeeService = service;
            _employeeTypeService = employeeTypeService;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var employeeList = _employeeService.GetAll();

            return View(employeeList);
        }

        public IActionResult AddEmployee()
        {
            var employee = new EmployeeDto();
            return PartialView("./_AddEmployee", employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employee)
        {
            _employeeService.Insert(employee);
            _toastNotification.Success("A new employee has been added.");
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return PartialView("./_EditEmployee", employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            _employeeService.Update(employeeDto);
            _toastNotification.Success("Changes has been saved.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeDto employeeDto)
        {
            _employeeService.DeleteEmployee(employeeDto);
            _toastNotification.Success("The employee has been deleted succesfully.");
            var employeeList = _employeeService.GetAll();
            return RedirectToAction("Index");
        }
    }
}
