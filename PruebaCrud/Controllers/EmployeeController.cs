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
            var employeetypes = _employeeTypeService.GetAll();
            ViewBag.EmployeeTypes = employeetypes;

            var employeeList = _employeeService.GetAll();

            return View(employeeList);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var employee = new EmployeeDto();
            var employeetypes = _employeeTypeService.GetAll();
            ViewBag.EmployeeTypes = employeetypes;

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


        public JsonResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return Json(employee);
        }

        public IActionResult EditEmployee()
        {
            ViewBag.EmployeeTypes = _employeeTypeService.GetAll();
            return PartialView("_EditEmployee");
        }

        [HttpPost]
        public JsonResult UpdateEmployee([FromBody] EmployeeDto EmployeeDto)
        {
            if (EmployeeDto is not null)
            {
                _employeeService.Update(EmployeeDto);
                _toastNotification.Success("Changes has been saved.");
                return Json(new { result = true });
            }
            _toastNotification.Error("An error has ocurred.");
            return Json(new { result = false});
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
