using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IReadOnlyList<Player>> GetPlayerAsync();
        Task<bool> DeletePlayerByIdAsync(int id);


    }
}