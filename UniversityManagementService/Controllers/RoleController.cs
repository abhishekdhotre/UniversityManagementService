using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementService.Repository;

namespace UniversityManagementService.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    [EnableCors("MyPolicy")]
    public class RoleController : Controller
    {
        public IRoleRepository RoleRepository { get; set; }

        public RoleController(IRoleRepository repository)
        {
            RoleRepository = repository;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roleList = await RoleRepository.GetAll();
            return Ok(roleList);
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await RoleRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        
        // POST: api/Role
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Role/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await RoleRepository.Remove(id);
            return NoContent();
        }
    }
}
