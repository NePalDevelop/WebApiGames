using System.Collections.Generic;

namespace WebApiGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudioId { get; set; }

        public string DeveloperStudioName { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
