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
    public class PodController : ControllerBase
    {
        private readonly IPodRepository _podRepository;

        public PodController(IPodRepository podRepository)
        {
            _podRepository = podRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetPods()
        {
            return Ok(_podRepository.GetAllPods());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetPodById(int id)
        {
            return Ok(_podRepository.GetPodById(id));
        }
        [HttpPost]
        public IActionResult CreatePod([FromBody] Pod pod)
        {
            if (pod == null)
                return BadRequest();

            if (pod.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Pod shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPod = _podRepository.AddPod(pod);

            return Created("pod", pod);
        }
        [HttpPut]
        public IActionResult UpdatePod([FromBody] Pod pod)
        {
            if (pod == null)
                return BadRequest();

            if (pod.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name of the Pod shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var podToUpdate = _podRepository.GetPodById(pod.PodId);

            if (pod == null)
                return NotFound();

            _podRepository.UpdatePod(pod);

            return NoContent(); //success
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePod(int id)
        {
            if (id == 0)
                return BadRequest();

            var podToDelete = _podRepository.GetPodById(id);
            if (podToDelete == null)
                return NotFound();

            _podRepository.DeletePod(id);

            return NoContent();//success
        }
    }
}