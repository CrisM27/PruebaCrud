using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeService _service;

        public EmployeeTypeController(IEmployeeTypeService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var employeeTypeList = _service.GetAll();
            return View(employeeTypeList);
        }
    }
}
