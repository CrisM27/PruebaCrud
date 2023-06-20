using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCrud.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: api/<StoreController>
        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StoreDto> GetAll()
        {
            try
            {
                var stores = _storeService.GetAll();
                return Ok();
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StoreDto> GetById(int id)
        {
            try
            {
                var store = _storeService.GetById(id);
                if (store != null)
                {
                    return store;
                }
                return NotFound();
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StoreDto> Add([FromBody] UpdateStoreDto updateStoreDto)
        {
            try
            {
                var storeDto = new StoreDto();
                storeDto.Name = updateStoreDto.Name;
                storeDto.Country = updateStoreDto.Country;
                storeDto.State = updateStoreDto.State;
                storeDto.City = updateStoreDto.City;
                storeDto.Zipcode = updateStoreDto.Zipcode;
                storeDto.Address = updateStoreDto.Address;

                if (storeDto.Name.Count() == 0 || storeDto.Name.Count() > 50)
                {
                    return BadRequest("Please check Name field");
                }

                if (storeDto.Country.Count() == 0 || storeDto.Country.Count() > 50)
                {
                    return BadRequest("Please check Country field");
                }

                if (storeDto.State.Count() == 0 || storeDto.State.Count() > 50)
                {
                    return BadRequest("Please check State field");
                }

                if (storeDto.City.Count() == 0 || storeDto.City.Count() > 50)
                {
                    return BadRequest("Please check City field");
                }

                if (storeDto.Zipcode.Count() == 0 || storeDto.Zipcode.Count() > 5)
                {
                    return BadRequest("Please check Zip Code field");
                }

                if (storeDto.Address.Count() == 0 || storeDto.Address.Count() > 255)
                {
                    return BadRequest("Please check Address field");
                }

                _storeService.Insert(storeDto);
                return NoContent();
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StoreDto> Edit(int id, [FromBody] UpdateStoreDto updateStoreDto)
        {
            try
            {
                var storeDto = _storeService.GetById(id);
                if (storeDto != null)
                {
                    storeDto.Name = updateStoreDto.Name;
                    storeDto.Country = updateStoreDto.Country;
                    storeDto.State = updateStoreDto.State;
                    storeDto.City = updateStoreDto.City;
                    storeDto.Zipcode = updateStoreDto.Zipcode;
                    storeDto.Address = updateStoreDto.Address;

                    if (storeDto.Name.Count() == 0 || storeDto.Name.Count() > 50)
                    {
                        return BadRequest("Please check Name field");
                    }
                    else
                    {
                        if (storeDto.Country.Count() == 0 || storeDto.Country.Count() > 50)
                        {
                            return BadRequest("Please check Country field");
                        }
                        else
                        {
                            if (storeDto.State.Count() == 0 || storeDto.State.Count() > 50)
                            {
                                return BadRequest("Please check State field");
                            }
                            else
                            {
                                if (storeDto.City.Count() == 0 || storeDto.City.Count() > 50)
                                {
                                    return BadRequest("Please check City field");
                                }
                                else
                                {
                                    if (storeDto.Zipcode.Count() == 0 || storeDto.Zipcode.Count() > 5)
                                    {
                                        return BadRequest("Please check Zip Code field");
                                    }
                                    else
                                    {
                                        if (storeDto.Address.Count() == 0 || storeDto.Address.Count() > 255)
                                        {
                                            return BadRequest("Please check Address field");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    _storeService.Update(storeDto);
                    return NoContent();
                }
                else
                {
                    return NotFound("Id does not exist");
                }
            }
            catch 
            {
                return StatusCode(500);
            }
            
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StoreDto> Delete(int id)
        {
            try
            {
                var storeDto = _storeService.GetById(id);
                if (storeDto != null)
                {
                    _storeService.Delete(storeDto);
                    return Ok();
                }
                return NoContent();
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
