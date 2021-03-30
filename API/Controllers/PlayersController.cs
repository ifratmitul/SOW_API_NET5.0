using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Error;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PlayersController : BaseApiController
    {
        private readonly StoreContext _context;
        private readonly IGenericRepository<Player> _playerRepo;
        private readonly IPlayerRepository _separatePlayerRepo;

        public PlayersController(StoreContext context, IGenericRepository<Player> playerRepo, IPlayerRepository separatePlayerRepo)
        {
            _separatePlayerRepo = separatePlayerRepo;
            _playerRepo = playerRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _playerRepo.GetAllAsync();
            //Getting all player using Generic Repo
            return Ok(players);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var isDeleted = await _separatePlayerRepo.DeletePlayerByIdAsync(id);
            //Delete player using Specific Player Repo, might seem like over kill but will need it later for expansion
            if (!isDeleted) return NotFound(new ApiResponse(404));

            return Ok("Deleted Successfully");
        }


        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player playerDetails)
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
                return BadRequest(new ApiResponse(500));
            }

            var itemToEdit = await _context.Players.FindAsync(id);
            if (itemToEdit == null)
            {
                return NotFound(new ApiResponse(404));
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