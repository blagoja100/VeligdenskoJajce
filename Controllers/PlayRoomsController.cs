using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeligdenskoJajce.Data;
using VeligdenskoJajce.Model;

namespace VeligdenskoJajce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayRoomsController : ControllerBase
    {
        private readonly VeligdenskoJajceContext _context;

        public PlayRoomsController(VeligdenskoJajceContext context)
        {
            _context = context;
        }

        // GET: api/PlayRooms
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<PlayRoom>>> GetPlayRooms()
        {
            return await _context.PlayRooms.ToListAsync();
        }

        // GET: api/allplayrooms
        [HttpGet]
        [Route("available")]
        public async Task<ActionResult<IEnumerable<PlayRoom>>> GetAvailablePlayRooms()
        {
            return await _context.PlayRooms.Where(r => r.SecondUserId == null).ToListAsync();
        }

        // GET: api/PlayRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayRoom>> GetPlayRoom(int id)
        {
            var playRoom = await _context.PlayRooms.FindAsync(id);

            if (playRoom == null)
            {
                return NotFound();
            }

            return playRoom;
        }

        // PUT: api/PlayRooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayRoom(int id, PlayRoom playRoom)
        {
            if (id != playRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(playRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }       

        [HttpPost]
        [Route("createroom")]
        public async Task<ActionResult<PlayRoom>> PostCreateRoom(PlayRoom playRoom)
        {
            _context.PlayRooms.Add(playRoom);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayRoom", new { id = playRoom.Id }, playRoom);
        }

        [HttpPost]
        [Route("joinroom")]
        public async Task<ActionResult<PlayRoom>> PostJoinRoom(GamePlay game)
        {
            if(game == null || game.RoomId == 0)
            {
                return CreatedAtAction("JoinRoom", new { id = 0 }, "Error joining a room");
            }

            var playRoom = _context.PlayRooms.FirstOrDefault(r => r.Id == game.RoomId);

            if(playRoom == null)
            {
                return NotFound("Room with Id not found.");
            }

            if(!string.IsNullOrWhiteSpace(playRoom.RoomPassword) && playRoom.RoomPassword != game.RoomPassword)
            {
                return BadRequest();
            }

            playRoom.SecondUserId = game.SecondUserId;
            playRoom.SecondUserName = game.SecondUserName;
            playRoom.SecondUserPictureUrl = game.SecondUserPictureUrl;
                        
            await _context.SaveChangesAsync();

            return Accepted(playRoom); // CreatedAtAction("JoinGame", new { id = game.RoomId }, game);
        }

        [HttpPost]
        [Route("gamestart")]
        public async Task<ActionResult<PlayRoom>> PostGameStarted(GameStart game)
        {
            if(game == null || game.RoomId == 0 || game.OwnerId == 0 || game.SecondUserId == 0)
            {
                return BadRequest();
            }            

            var gameRoom = _context.PlayRooms.FirstOrDefault(g => g.Id == game.RoomId && g.OwnerId == game.OwnerId && g.SecondUserId == game.SecondUserId);

            if(gameRoom == null)
            {
                return NoContent();
            }

            gameRoom.IsGameStarted = true;
            gameRoom.HasWinner = true;

            var randomNumber = new Random().Next();
            gameRoom.IsOwnerWinner = randomNumber % 2 == 0;

            await _context.SaveChangesAsync();

            return Accepted(gameRoom);
        }

        // DELETE: api/PlayRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayRoom>> DeletePlayRoom(int id)
        {
            var playRoom = await _context.PlayRooms.FindAsync(id);
            if (playRoom == null)
            {
                return NotFound();
            }

            _context.PlayRooms.Remove(playRoom);
            await _context.SaveChangesAsync();

            return playRoom;
        }

        private bool PlayRoomExists(int id)
        {
            return _context.PlayRooms.Any(e => e.Id == id);
        }
    }
}
