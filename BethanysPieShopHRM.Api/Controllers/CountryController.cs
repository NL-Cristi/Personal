using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetAllCountries());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_countryRepository.GetCountryById(id));
        }
        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest();

            if (country.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Country shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEmployee = _countryRepository.AddCountry(country);

            return Created("country", country);
        }
        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest();

            if (country.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Country shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryToUpdate = _countryRepository.GetCountryById(country.CountryId);

            if (country == null)
                return NotFound();

            _countryRepository.UpdateCountry(country);

            return NoContent(); //success
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            if (id == 0)
                return BadRequest();

            var countryToDelete = _countryRepository.GetCountryById(id);
            if (countryToDelete == null)
                return NotFound();

            _countryRepository.DeleteCountry(id);

            return NoContent();//success
        }
    }
}
