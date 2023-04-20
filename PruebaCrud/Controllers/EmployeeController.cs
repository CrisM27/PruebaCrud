using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

namespace PruebaCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly PruebaCrudContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
           _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            //var employeeList = _context.Employees.ToList();
            var employeeList = _employeeService.GetAll();
            return View(employeeList);
        }
    }
}
