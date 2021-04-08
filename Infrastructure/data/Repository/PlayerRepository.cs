using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly StoreContext _context;
        public PlayerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Player>> GetPlayerAsync()
        {

            return await _context.Players.ToListAsync();
        }

        public async Task<bool> DeletePlayerByIdAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return false;
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}