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

        // GET: api/users/{id}/{gameid}
        [HttpGet("{userId}/{gameId}")]
        public async Task<ActionResult<GameData>> GetUser(string userId, string gameId)
        {
            var gameData = await _context.GameData
                .FirstOrDefaultAsync(g => g.UserId == userId && g.GameId == gameId);

            if (gameData == null)
            {
                return NotFound();
            }
            return Ok(gameData);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<GameData>> CreateUser([FromBody] GameData newGameData)
        {
            if (string.IsNullOrEmpty(newGameData.UserId) || string.IsNullOrEmpty(newGameData.GameId))
            {
                return BadRequest("UserId and GameId must be provided.");
            }

            var existingGameData = await _context.GameData
                .FirstOrDefaultAsync(g => g.UserId == newGameData.UserId && g.GameId == newGameData.GameId);

            if (existingGameData != null)
            {
                return Conflict("A record with the specified UserId and GameId already exists.");
            }

            _context.GameData.Add(newGameData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { userId = newGameData.UserId, gameId = newGameData.GameId }, newGameData);
        }

        // PUT: api/users/{Id}/{gameId}
        [HttpPut("{userId}/{gameId}")]
        public async Task<IActionResult> UpdateUser(string userId, string gameId, [FromBody] string body)
        {
            var gameData = await _context.GameData
                .FirstOrDefaultAsync(g => g.UserId == userId && g.GameId == gameId);

            if (gameData == null)
            {
                return NotFound();
            }

            gameData.Body = body;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{userId}/{gameId}")]
        public async Task<IActionResult> DeleteUser(string userId, string gameId)
        {
            var gameData = await _context.GameData
                .FirstOrDefaultAsync(g => g.UserId == userId && g.GameId == gameId);

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
