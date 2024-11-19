using Microsoft.AspNetCore.Mvc;
using HovedOpgaveWebAPI.Models;
using HovedOpgaveWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace HovedOpgaveWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameData>>> GetUsers()
        {
            var gameData = await _context.GameData.ToListAsync();
            return Ok(gameData);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GameData>> GetUser(int id)
        {
            var gameData = await _context.GameData.FindAsync(id);
            if (gameData == null)
            {
                return NotFound();
            }
            return Ok(gameData);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<GameData>> CreateUser([FromBody] string body)
        {
            var newGameData = new GameData
            {
                GameId = 1, 
                Body = body 
            };

            _context.GameData.Add(newGameData);
            
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = newGameData.UserId }, newGameData);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] string body)
        {
            var gameData = await _context.GameData.FindAsync(id);

            if (gameData == null)
            {
                return NotFound();
            }

            gameData.Body = body;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var gameData = await _context.GameData.FindAsync(id);
            if (gameData == null)
            {
                return NotFound();
            }

            _context.GameData.Remove(gameData);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
