using System;
using System.Collections.Generic;
using BethanysPieShopHRM.Api.Models;
using Microsoft.AspNetCore.Mvc;


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
    }
}
