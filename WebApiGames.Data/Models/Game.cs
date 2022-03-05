using System.Collections.Generic;

namespace WebApiGames.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DeveloperStudioId { get; set; }

        public DeveloperStudio DeveloperStudio { get; set; }

        public List<GamesGenreRelation> GenresRelation { get; set; }
    }
}
