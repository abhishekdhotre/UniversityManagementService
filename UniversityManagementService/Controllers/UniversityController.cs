using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementService.Models;
using UniversityManagementService.Repository;

namespace UniversityManagementService.Controllers
{
    [Produces("application/json")]
    [Route("api/University")]
    [EnableCors("MyPolicy")]
    public class UniversityController : Controller
    {
        public IUniversityRepository UniversityRepository { get; set; }

        public UniversityController(IUniversityRepository repository)
        {
            UniversityRepository = repository;
        }

        // GET: api/University
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var universityList = await UniversityRepository.GetAll();
            return Ok(universityList);
        }

        // GET: api/University/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await UniversityRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/University
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] University item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await UniversityRepository.Add(item);
            return Created("api/University", item);
            // return CreatedAtRoute("GetUniversity", new { Controller = "University", id = item.Id }, item);
        }

        // PUT: api/University/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] University item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var UniversityObj = await UniversityRepository.Find(id);
            if (UniversityObj == null)
            {
                return NotFound();
            }
            await UniversityRepository.Update(id, item);
            return NoContent();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await UniversityRepository.Remove(id);
            return NoContent();
        }
    }
}
