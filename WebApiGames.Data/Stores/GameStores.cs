using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiGames.Domain.Interfaces;
using WebApiGames.Data.Models;
using WebApiGames.Domain.Models;

namespace WebApiGames.Data.Stores
{
    public class GameStores: IGameStores
    {
        private readonly GamesContext _context;

        public GameStores(GamesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Game>> GetGames()
        {
            var query = _context.Games.Include(g => g.DeveloperStudio)
                .Include(g => g.GenresRelation)
                .ThenInclude(gr => gr.Genre);

            return await query.ToListAsync();
        }

        public async Task<Game> GetGame(int id)
        {
            return await _context.Games.Include(g => g.DeveloperStudio)
                .Include(g => g.GenresRelation)
                .ThenInclude(gr => gr.Genre)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Game> AddGame(Game game)
        {
            _context.Add(game);

            await _context.SaveChangesAsync();

            return await _context.Games.Include(g => g.DeveloperStudio)
                .Include(g => g.GenresRelation)
                .ThenInclude(gr => gr.Genre)
                .FirstOrDefaultAsync(g => g.Name == game.Name);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            if (!await GameExist(game.Id))
            {
                return null;
            }

            _context.Update(game);
            await _context.SaveChangesAsync();

            return await _context.Games.Include(g => g.DeveloperStudio)
                .Include(g => g.GenresRelation)
                .ThenInclude(gr => gr.Genre)
                .FirstOrDefaultAsync(g => g.Name == game.Name);
        }

        public async Task DeleteGame(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> GameExist(int id)
        {
            return await _context.Games.AnyAsync(g => g.Id == id);
        }

    }
}
