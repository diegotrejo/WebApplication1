using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "Alice@hotmail.com" },
            new User { Id = 2, Name = "Bob", Email = "Bob@hotmail.com" },
            new User { Id = 3, Name = "Charlie", Email = "Charlie@hotmail.com" },
            new User { Id = 4, Name = "Thomas", Email = "Thomas@hotmail.com" },
            new User { Id = 5, Name = "Ingrid", Email = "Ingrid@hotmail.com" },
            new User { Id = 6, Name = "Megan", Email = "Megan@hotmail.com" },
            new User { Id = 7, Name = "Peter", Email = "Peter@hotmail.com" },
            new User { Id = 8, Name = "William", Email = "William@hotmail.com" },
            new User { Id = 9, Name = "Sarah", Email = "Sarah@hotmail.com" },
            new User { Id = 10, Name = "Duncan", Email = "Duncan@hotmail.com" },
        };

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return users.Count() > 0 ? Ok(users) : NotFound();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return user != null ? Ok(user) : NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
            return existingUser != null ? Ok(existingUser) : NotFound();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return user != null ? NoContent() : NotFound();
        }
    }
}
