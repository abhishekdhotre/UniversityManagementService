using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementService.Repository;

namespace UniversityManagementService.Controllers
{
    [Produces("application/json")]
    [Route("api/University")]
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
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/University/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
