using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using PruebaCrud.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCrud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _employeeTypeService;

        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            _employeeTypeService = employeeTypeService;
        }

        // GET: api/<EmployeeTypeController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeTypeDto> GetAll()
        {
            try
            {
                var employeeTypes = _employeeTypeService.GetAll();
                return Ok();
            }
            catch 
            {
                return StatusCode(500);
            }  
        }

        // GET api/<EmployeeTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeTypeDto> GetById(int id)
        {
            var employeeType = _employeeTypeService.GetById(id);
            if (employeeType != null) 
            {
                return employeeType;
            }
            return NotFound("El Id no existe");
        }

        // POST api/<EmployeeTypeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeTypeDto> Add([FromBody] UpdateEmployeeTypeDto updateEmployeeTypeDto)
        {
            var employeeTypeDto = new EmployeeTypeDto();
            employeeTypeDto.EmployeeRole = updateEmployeeTypeDto.EmployeeRole;
            employeeTypeDto.Salary = updateEmployeeTypeDto.Salary;

            if (employeeTypeDto.EmployeeRole.Count() == 0 || employeeTypeDto.EmployeeRole.Count() >50)
            {
                return BadRequest("Please check Employee Role field");
            }

            if (employeeTypeDto.EmployeeTypeID.ToString().Count() == 0 || employeeTypeDto.EmployeeTypeID.ToString().Count() > 12)
            {
                return BadRequest("Please check Salary field");
            }

            _employeeTypeService.Insert(employeeTypeDto);
            return NoContent();
        }

        // PUT api/<EmployeeTypeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeTypeDto> Edit(int id, [FromBody] UpdateEmployeeTypeDto updateEmployeeTypeDto)
        {
            var employeeTypeDto = _employeeTypeService.GetById(id);
            if (employeeTypeDto != null)
            {
                employeeTypeDto.EmployeeRole = updateEmployeeTypeDto.EmployeeRole;
                employeeTypeDto.Salary = updateEmployeeTypeDto.Salary;
                if (employeeTypeDto.EmployeeRole.Count() == 0 || employeeTypeDto.EmployeeRole.Count() > 50)
                {
                    return BadRequest("Please check Employee Role field");
                }
                else 
                {
                    if (employeeTypeDto.EmployeeTypeID.ToString().Count() == 0 || employeeTypeDto.EmployeeTypeID.ToString().Count() > 12)
                    {
                        return BadRequest("Please check Salary field");
                    }
                }
           
                _employeeTypeService.Update(employeeTypeDto);
                return NoContent();
            }
            return NotFound("El Id no existe");
        }

        // DELETE api/<EmployeeTypeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmployeeTypeDto> Delete(int id)
        {
            var employeetype = _employeeTypeService.GetById(id);
            if (employeetype != null)
            {
                _employeeTypeService.Delete(employeetype);
                return Ok();
            }
            return NotFound();
        }
    }
}
