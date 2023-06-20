using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCrud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/<AttendanceController>
        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<AttendanceDto> GetAll()
        {
            var attendances = _attendanceService.GetAll();
            return attendances;
        }

        // POST api/<AttendanceController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AttendanceDto> Post([FromBody] UpdateAttendanceDto updateAttendanceDto)
        {
            var attendanceDto = new AttendanceDto();

            attendanceDto.StoreID = updateAttendanceDto.StoreID;
            attendanceDto.EmployeeID = updateAttendanceDto.EmployeeID;
            attendanceDto.AttendanceDate = updateAttendanceDto.AttendanceDate;

            return NoContent();
        }
    }
}
