using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiGames.Domain.Interfaces;
using WebApiGames.Data.Models;
using WebApiGames.Domain.Models;
using System.Linq;

namespace WebApiGames.Data.Store
{
    public class GameStore: IGameStore
    {
        private readonly GamesContext _context;

        public GameStore(GamesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Game>> GetGames(GameQuery filter)
        {
            IQueryable<Data.Models.Game> query;

            if (!string.IsNullOrEmpty(filter.Genre))
            {
                query = _context.Games.Where(g => g.GenresRelation.Select(gr => gr.Genre).Any(g => g.Name == filter.Genre))
                    .Include(g => g.DeveloperStudio)
                    .Include(g => g.GenresRelation)
                    .ThenInclude(gr => gr.Genre);
            }
            else
            {
                query = _context.Games.Include(g => g.DeveloperStudio)
                    .Include(g => g.GenresRelation)
                    .ThenInclude(gr => gr.Genre);
            }

            var games = await query.ToListAsync();

            return  games.Select(Mapper.MapGameToDomain).ToList();
        }

        public async Task<Domain.Models.Game> GetGame(int id)
        {
            var game = await _context.Games.Include(g => g.DeveloperStudio)
                .Include(g => g.GenresRelation)
                .ThenInclude(gr => gr.Genre)
                .FirstOrDefaultAsync(g => g.Id == id);
            return Mapper.MapGameToDomain(game);
        }

        public async Task<Domain.Models.Game> AddGame(Domain.Models.Game game)
        {
            if (game == null) return null;

            var addGame = new Data.Models.Game
            {
                Name = game.Name,
                DeveloperStudioId = game.StudioId,
                GenresRelation = game.Genres.Select(g => new GamesGenreRelation
                {
                    GenreId = g.Id
                }).ToList()
            };

            _context.Add(addGame);

            await _context.SaveChangesAsync();

            return await GetGame(addGame.Id);
        }

        public async Task<Domain.Models.Game> UpdateGame(Domain.Models.Game game)
        {
            if (!await GameExist(game.Id))
            {
                return null;
            }

            var updatedGame = new Data.Models.Game 
            {
                Id = game.Id,
                Name = game.Name,
                DeveloperStudioId = game.StudioId,
                GenresRelation = game.Genres.Select(g => new GamesGenreRelation
                {
                    GenreId = g.Id
                }).ToList()
            };

            var deleteRelation = await _context.GamesGenreRelations.Where(g => g.GameId == game.Id).ToListAsync();

            _context.RemoveRange(deleteRelation);

            _context.Update(updatedGame);

            await _context.SaveChangesAsync();

            return await GetGame(updatedGame.Id);
        }

        public async Task<bool> DeleteGame(int id)
        {
            var deleteGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (deleteGame == null) return false;

            var deleteRelation = await _context.GamesGenreRelations.Where(g => g.GameId == id).ToListAsync();

            _context.RemoveRange(deleteRelation);

            _context.Games.Remove(deleteGame);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GameExist(int id)
        {
            return await _context.Games.AnyAsync(g => g.Id == id);
        }
    }
}
