using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiGames.Domain.Models;

namespace WebApiGames.Domain.Interfaces
{
    public interface IGameStore
    {
        public Task<IEnumerable<Game>> GetGames(GameQuery gameQuery);

        public Task<Game> GetGame(int id);

        public Task<Game> AddGame(Game game);

        public Task<Game> UpdateGame(Game game);

        public Task<bool> DeleteGame(int id);
    }
}
