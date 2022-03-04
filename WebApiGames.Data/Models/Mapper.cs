using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGames.Domain.Models;


namespace WebApiGames.Data.Models
{
    public static class Mapper
    {
        public static Game MapGameFromDomain(Domain.Models.Game game)
        {
            if (game == null) return null;

            Game dataGame = new Game
            {
                Id = game.Id,
                Name = game.Name,
                StudioId = game.StudioId,
                DeveloperStudio = new DeveloperStudio
                {
                    Id = game.StudioId,
                    StudioName = game.DeveloperStudioName
                },
                GenresRelation = game.Genres.Select(g => new GamesGenreRelation
                {
                    GameId = game.Id,
                    GenreId = g.Id
                }).ToList()
            };

            return dataGame;
        }

        public static Domain.Models.Game MapGameToDomain(Game game)
        {
            if (game == null) return null;

            Domain.Models.Game domainGame = new Domain.Models.Game
            {
                Id = game.Id,
                Name = game.Name,
                StudioId = game.StudioId,
                DeveloperStudioName = game.DeveloperStudio.StudioName,
                Genres = game.GenresRelation.Select(g => new Domain.Models.Genre
                {
                    Id = g.Id,
                    Name = g.Genre.Name
                }).ToList()
            };

            return domainGame;
        }
    }
}




public ICollection<GamesGenreRelation> GenresRelation { get; set; }