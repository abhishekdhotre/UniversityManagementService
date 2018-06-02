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
    [Route("api/School")]
    [EnableCors("MyPolicy")]
    public class SchoolController : Controller
    {
        public ISchoolRepository SchoolRepository { get; set; }

        public SchoolController(ISchoolRepository repository)
        {
            SchoolRepository = repository;
        }

        // GET: api/School
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schoolList = await SchoolRepository.GetAll();
            return Ok(schoolList);
        }

        // GET: api/School/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await SchoolRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/School
        [EnableCors("MyPolicy")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/School/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] School item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var schoolObj = await SchoolRepository.Find(id);
            if (schoolObj == null)
            {
                return NotFound();
            }
            await SchoolRepository.Update(id, item);
            return NoContent();
        }

        //// DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
