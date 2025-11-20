using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new List<User> {
                new User { Id = 1, Name = "Alice", Email = "jjjj" },
                new User { Id = 2, Name = "Bob", Email = "bbbb" },
                new User { Id = 3, Name = "Charlie", Email = "cccc" }
            };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return new User { Id = 1, Name = "Alice", Email = "jjjj" };
        }

        // POST api/<UsersController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            user.Id = 44; // Simulate assigning a new ID
            return user;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            return user;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
