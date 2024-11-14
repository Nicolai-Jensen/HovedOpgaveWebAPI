using Microsoft.AspNetCore.Mvc;
using HovedOpgaveWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HovedOpgaveWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Temporary in-memory Dictionary to store users
        private static Dictionary<int, UserDetails> users = new Dictionary<int, UserDetails>
        {
            { 1, new UserDetails { Gender = "Female", Volume = 10, Money = 100.50m, Chips = 5, RewardNames = new List<string> { "Reward1", "Reward2" } } },
            { 2, new UserDetails { Gender = "Male", Volume = 20, Money = 150.00m, Chips = 3, RewardNames = new List<string> { "Reward3" } } }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<string> GetUsers()
        {
            var json = JsonConvert.SerializeObject(users);
            return Ok(json);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDetails> GetUser(int id)
        {
            if (users.TryGetValue(id, out var userDetails))
            {
                return Ok(userDetails);
            }
            return NotFound();
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<CreateUserResponse> CreateUser(UserDetails newUser)
        {
            int newId = users.Count > 0 ? users.Keys.Max() + 1 : 1;
            users[newId] = newUser;

            var response = new CreateUserResponse
            {
                Id = newId,
                User = newUser 
            };

            return CreatedAtAction(nameof(GetUser), new { id = newId }, response);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserDetails updatedUser)
        {
            if (!users.ContainsKey(id))
            {
                return NotFound();
            }

            users[id] = updatedUser;
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!users.ContainsKey(id))
            {
                return NotFound();
            }

            users.Remove(id);
            return NoContent();
        }
        
    }

    public class CreateUserResponse
    {
        public int Id { get; set; }
        public UserDetails? User { get; set; }  // Nullable to avoid initialization warnings
    }

}