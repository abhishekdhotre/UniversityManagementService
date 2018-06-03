using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementService.Models;
using UniversityManagementService.Repository;

namespace UniversityManagementService.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [EnableCors("MyPolicy")]
    public class UserController : Controller
    {
        public IUserRepository UserRepository { get; set; }

        public UserController(IUserRepository repository)
        {
            UserRepository = repository;
        }

        // GET: api/User
       [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await UserRepository.GetAll();
            return Ok(userList);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await UserRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/User
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await UserRepository.Add(item);
            return Created("api/User", item);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var userObj = await UserRepository.Find(id);
            if (userObj == null)
            {
                return NotFound();
            }
            await UserRepository.Update(id, item);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await UserRepository.Remove(id);
            return NoContent();
        }
    }
}
