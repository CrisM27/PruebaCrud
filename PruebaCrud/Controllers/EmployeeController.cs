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

        public EmployeeController(IEmployeeService service, IEmployeeTypeService employeeTypeService, INotyfService toastNotification)
        {
            _employeeService = service;
            _employeeTypeService = employeeTypeService;
        }
        public IActionResult Index()
        {
            var employeeList = _employeeService.GetAll();

            return View(employeeList);
        }
    }
}
