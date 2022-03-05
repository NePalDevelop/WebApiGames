using System.Linq;
using WebApiGames.Models;

namespace WebApiGames.Helper
{
    public static class Mapper
    {
        public static Game MapGameFromDomain(Domain.Models.Game game)
        {
            if (game == null) return null;

            Game modelGame = new()
            {
                Id = game.Id,
                Name = game.Name,
                StudioId = game.StudioId,
                DeveloperStudioName = game.DeveloperStudioName,
                Genres = game.Genres.Select(g => new Genre
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };

            return modelGame;
        }

        public static Domain.Models.Game MapGameToDomain(Game game)
        {
            if (game == null) return null;

            Domain.Models.Game domainGame = new()
            {
                Id = game.Id,
                Name = game.Name,
                StudioId = game.StudioId,
                DeveloperStudioName = game.DeveloperStudioName,
                Genres = game.Genres.Select(g => new Domain.Models.Genre
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList()
            };

            return domainGame;
        }
    }
}
