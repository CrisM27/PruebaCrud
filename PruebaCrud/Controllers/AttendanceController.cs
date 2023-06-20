using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IEmployeeService _employeeService;
        private readonly IStoreService _storeService;
        private readonly INotyfService _toastNotification;

        public AttendanceController(IAttendanceService service, INotyfService toastNotification, IEmployeeService employeeService, IStoreService storeService)
        {
            _attendanceService = service;
            _toastNotification = toastNotification;
            _employeeService = employeeService;
            _storeService = storeService;
        }
        public IActionResult Index()
        {
            var attendanceList = _attendanceService.GetAll();
            return View(attendanceList);
        }

        public IActionResult Add()
        {
            var attendance = new AttendanceDto();
            return PartialView("./_AddAttendance", attendance);
        }

        [HttpPost]
        public IActionResult Add(AttendanceDto attendance)
        {
            var employeeCheck = _employeeService.GetEmployee(attendance.EmployeeID);
            var storeCheck = _storeService.GetById(attendance.StoreID);
            if (employeeCheck == null || storeCheck == null)
            {
                _toastNotification.Error("Employee ID or Store ID are not valid.");
                return RedirectToAction("Index");
            }
            else 
            {
                _attendanceService.Add(attendance);
                _toastNotification.Success("A new attendance record has been added.");
                var attendanceList = _attendanceService.GetAll();
                return RedirectToAction("Index");
            }
        }
    }
}
