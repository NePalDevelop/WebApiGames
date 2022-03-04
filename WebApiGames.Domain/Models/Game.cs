using System.Collections.Generic;

namespace WebApiGames.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudioId { get; set; }

        public DeveloperStudio DeveloperStudio { get; set; }

        public ICollection<GamesGenreRelation> GenresRelation { get; set; }
    }
}
