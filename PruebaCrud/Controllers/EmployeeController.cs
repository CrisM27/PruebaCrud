using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.DAL;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

namespace PruebaCrud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
           _service = service;
        }
        public IActionResult Index()
        {
            var employeeList = _service.GetAll();
            return View(employeeList);
        }
    }
}
