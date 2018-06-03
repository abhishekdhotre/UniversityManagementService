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
    [Route("api/UniversityRole")]
    [EnableCors("MyPolicy")]
    public class UniversityRoleController : Controller
    {
        public IRoleRepository RoleRepository { get; set; }

        public UniversityRoleController(IRoleRepository repository)
        {
            RoleRepository = repository;
        }

        // GET: api/UniversityRole
        [HttpGet]
        public IActionResult Get()
        {
            var universityRoleList = RoleRepository.GetMappings();
            return Ok(universityRoleList);
        }

        // GET: api/UniversityRole/5/2
        [HttpGet("{universityId}/{roleId}")]
        public async Task<IActionResult> Get(int universityId, int roleId)
        {
            var item = await RoleRepository.Find(universityId, roleId);
            if (item == null)
            {
                var blankData = new UniversityRole
                {
                    RoleId = 0,
                    UniversityId = 0
                };
                return Ok(blankData);
            }
            return Ok(item);
        }

        // POST: api/UniversityRole
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UniversityRole item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await RoleRepository.AddMapping(item);
            return Created("api/Role", item);
        }

        // PUT: api/UniversityRole/5
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
