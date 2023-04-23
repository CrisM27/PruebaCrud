using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendaceService _service;

        public AttendanceController(IAttendaceService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var attendanceList = _service.GetAll();
            return View(attendanceList);
        }
    }
}
