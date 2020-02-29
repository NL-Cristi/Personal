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
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeController(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetOffices()
        {
            return Ok(_officeRepository.GetAllOffices());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetOfficeById(int id)
        {
            return Ok(_officeRepository.GetOfficeById(id));
        }
        [HttpPost]
        public IActionResult CreateOffice([FromBody] Office office)
        {
            if (office == null)
                return BadRequest();

            if (office.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Office shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOffice = _officeRepository.AddOffice(office);

            return Created("office", office);
        }
        [HttpPut]
        public IActionResult UpdateOffice([FromBody] Office office)
        {
            if (office == null)
                return BadRequest();

            if (office.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Office shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityToUpdate = _officeRepository.GetOfficeById(office.OfficeId);

            if (office == null)
                return NotFound();

            _officeRepository.UpdateOffice(office);

            return NoContent(); //success
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            if (id == 0)
                return BadRequest();

            var officeToDelete = _officeRepository.GetOfficeById(id);
            if (officeToDelete == null)
                return NotFound();

            _officeRepository.DeleteOffice(id);

            return NoContent();//success
        }
    }
}