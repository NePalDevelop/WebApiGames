using System.Linq;

namespace WebApiGames.Data.Models
{
    public static class Mapper
    {
        public static Domain.Models.Game MapGameToDomain(Game game)
        {
            if (game == null) return null;

            Domain.Models.Game domainGame = new Domain.Models.Game
            {
                Id = game.Id,
                Name = game.Name,
                StudioId = game.DeveloperStudioId,
                DeveloperStudioName = game.DeveloperStudio.StudioName,
                Genres = game.GenresRelation.Select(g => new Domain.Models.Genre
                {
                    Id = g.GenreId,
                    Name = g.Genre.Name
                }).ToList()
            };

            return domainGame;
        }
    }
}
