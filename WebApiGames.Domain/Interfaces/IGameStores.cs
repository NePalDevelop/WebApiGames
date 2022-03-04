using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiGames.Domain.Models;

namespace WebApiGames.Domain.Interfaces
{
    public interface IGameStores
    {
        public Task<IEnumerable<Game>> GetGames();

        public Task<Game> GetGame(int id);

        public Task<Game> AddGame(Game game);

        public Task<Game> UpdateGame(Game game);

        public Task DeleteGame(Game game);
    }
}
