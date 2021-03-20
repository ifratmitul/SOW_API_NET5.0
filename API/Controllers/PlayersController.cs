using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PlayersController : BaseApiController
    {
        private readonly StoreContext _context;
        public PlayersController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Player>> CreateTodoItem(Player playerDetails)
        {
            var ItemToEnter = new Player
            {
                Name = playerDetails.Name,
                PlayingPeriod = playerDetails.PlayingPeriod,
                Position = playerDetails.Position
            };

            _context.Players.Add(ItemToEnter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPlayers),
                new { id = ItemToEnter.Id });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, Player playerDetails)
        {
            if (id != playerDetails.Id)
            {
                return BadRequest();
            }

            var itemToEdit = await _context.Players.FindAsync(id);
            if (itemToEdit == null)
            {
                return NotFound();
            }

            itemToEdit.Name = playerDetails.Name;
            itemToEdit.PlayingPeriod = playerDetails.PlayingPeriod;
            itemToEdit.Position = playerDetails.Position;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PlayerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool PlayerExists(long id) =>
             _context.Players.Any(e => e.Id == id);

    }
}