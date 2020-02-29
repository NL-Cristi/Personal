using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCites()
        {
            return Ok(_cityRepository.GetAllCities());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            return Ok(_cityRepository.GetCityById(id));
        }
        [HttpPost]
        public IActionResult CreateCountry([FromBody] City city)
        {
            if (city == null)
                return BadRequest();

            if (city.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the City shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCity = _cityRepository.AddCity(city);

            return Created("city", city);
        }
        [HttpPut]
        public IActionResult UpdateCity([FromBody] City city)
        {
            if (city == null)
                return BadRequest();

            if (city.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the City shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityToUpdate = _cityRepository.GetCityById(city.CityId);

            if (city == null)
                return NotFound();

            _cityRepository.UpdateCity(city);

            return NoContent(); //success
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            if (id == 0)
                return BadRequest();

            var cityToDelete = _cityRepository.GetCityById(id);
            if (cityToDelete == null)
                return NotFound();

            _cityRepository.DeleteCity(id);

            return NoContent();//success
        }
    }
}