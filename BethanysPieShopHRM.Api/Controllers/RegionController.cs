using System;
using System.Collections.Generic;
//using System.Drawing;
using BethanysPieShopHRM.Api.Models;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShopHRM.Shared;


namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetRegions()
        {
            return Ok(_regionRepository.GetAllRegions());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_regionRepository.GetRegionById(id));
        }
        // POST: api/<controller>
        [HttpPost]
        public IActionResult CreateRegion([FromBody] Region region)
        {
            if (region == null)
                return BadRequest();

            if (region.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Region shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEmployee = _regionRepository.AddRegion(region);

            return Created("region", region);
        }
        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Region region)
        {
            if (region == null)
                return BadRequest();

            if (region.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Region shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regionToUpdate = _regionRepository.GetRegionById(region.RegionId);

            if (region == null)
                return NotFound();

            _regionRepository.UpdateRegion(region);

            return NoContent(); //success
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(int id)
        {
            if (id == 0)
                return BadRequest();

            var regionToDelete = _regionRepository.GetRegionById(id);
            if (regionToDelete == null)
                return NotFound();

            _regionRepository.DeleteRegion(id);

            return NoContent();//success
        }
    }
}