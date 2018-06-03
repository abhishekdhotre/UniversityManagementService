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
    [Route("api/RoleUser")]
    public class RoleUserController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public RoleUserController(IUserRepository repository)
        {
            UserRepository = repository;
        }

        // GET: api/RoleUser
        [HttpGet]
        public IActionResult Get()
        {
            var roleUserList = UserRepository.GetMappings();
            return Ok(roleUserList);
        }

        // GET: api/RoleUser/5
        [HttpGet("{roleId}/{userId}")]
        public async Task<IActionResult> Get(int roleId, int userId)
        {
            var item = await UserRepository.Find(roleId, userId);
            if (item == null)
            {
                var blankData = new RoleUser
                {
                    RoleId = 0,
                    UserId = 0
                };
                return Ok(blankData);
            }
            return Ok(item);
        }

        // POST: api/RoleUser
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleUser item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await UserRepository.AddMapping(item);
            return Created("api/RoleUser", item);
        }

        // DELETE: api/RoleUser/5
        [HttpDelete("{roleId}/{userId}")]
        public async Task<IActionResult> Delete(int roleId, int userId)
        {
            await UserRepository.Remove(roleId, userId);
            return NoContent();
        }
    }
}
