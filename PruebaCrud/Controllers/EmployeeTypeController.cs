using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

namespace PruebaCrud.Web.Controllers
{
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeService _service;
        private readonly INotyfService _toastNotification;

        public EmployeeTypeController(IEmployeeTypeService service, INotyfService toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var employeeTypeList = _service.GetAll();
            return View(employeeTypeList);
        }

        public IActionResult Add()
        {
            var employeeType = new EmployeeTypeDto();
            return PartialView("./_AddEmployeeType",employeeType);
        }

        [HttpPost]
        public IActionResult Add(EmployeeTypeDto employeeType)
        {
            _service.Insert(employeeType);
            _toastNotification.Success("A new employee type has been added successfuly.");
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            var employeeType = _service.GetById(id);
            return PartialView("./_EditEmployeeType", employeeType);
        }

        [HttpPost]
        public IActionResult Update(EmployeeTypeDto employeeType)
        {
            _service.Update(employeeType);
            _toastNotification.Success("Changes has been saved.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(EmployeeTypeDto employeeType)
        {
            _service.Delete(employeeType);
            _toastNotification.Success("The employee type has been deleted succesfully.");
            var employeeTypeList = _service.GetAll();
            return RedirectToAction("Index");
        }
    }
}
