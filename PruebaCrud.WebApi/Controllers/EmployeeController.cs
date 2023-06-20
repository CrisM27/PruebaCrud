using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService { get; set; }

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> GetAll()
        {
            try
            {
                var employeesDto = _employeeService.GetAll();
                return Ok();
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> GetById(int id)
        {
            try
            {
                var employeeDto = _employeeService.GetEmployee(id);
                if (employeeDto != null)
                {
                    return employeeDto;
                }
                return NotFound("Id does not exist");
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> Add([FromBody] AddEmployeeDto addEmployeeDto)
        {
            try
            {
                var employeeDto = new EmployeeDto();
                employeeDto.Name = addEmployeeDto.Name;
                employeeDto.Telephone = addEmployeeDto.Telephone;
                employeeDto.EmploymentDate = addEmployeeDto.EmploymentDate;
                employeeDto.EmployeeTypeID = addEmployeeDto.EmployeeTypeID;
                _employeeService.Insert(employeeDto);

                if (employeeDto.Name.Count() == 0 || employeeDto.Name.Count() > 50)
                {
                    return BadRequest("Please check Name field");
                }

                if (employeeDto.Telephone.Count() == 0 || employeeDto.Telephone.Count() > 20)
                {
                    return BadRequest("Please check Telephone field");
                }

                if (employeeDto.EmployeeTypeID == 0)
                {
                    return BadRequest("Please check Employee Type ID field");
                }
                return NoContent();
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> Edit(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                var employeeDto = _employeeService.GetEmployee(id);
                if (employeeDto != null)
                {
                    employeeDto.Name = updateEmployeeDto.Name;
                    employeeDto.Telephone = updateEmployeeDto.Telephone;
                    employeeDto.EmployeeTypeID = updateEmployeeDto.EmployeeTypeID;

                    if (employeeDto.Name.Count() == 0 || employeeDto.Name.Count() > 50)
                    {
                        return BadRequest("Please check Name field");
                    }
                    else
                    {
                        if (employeeDto.Telephone.Count() == 0 || employeeDto.Telephone.Count() > 20)
                        {
                            return BadRequest("Please check Telephone field");
                        }
                        else
                        {
                            if (employeeDto.EmployeeTypeID == 0 || employeeDto.EmployeeTypeID < 0)
                            {
                                return BadRequest("Please check Employee Type ID field");
                            }
                        }
                    }
                    _employeeService.Update(employeeDto);
                    return NoContent();
                }
                return NotFound("Id does not exist");
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeDto> Delete(int id)
        {
            try
            {
                var employeeDto = _employeeService.GetEmployee(id);
                if (employeeDto != null)
                {
                    _employeeService.DeleteEmployee(employeeDto);
                    return Ok();
                }
                return NotFound("Id does not exist");
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
