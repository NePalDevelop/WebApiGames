using System.Collections.Generic;

namespace WebApiGames.Data.Models
{
    public class DeveloperStudio
    {
        public int Id { get; set; }
        
        public string StudioName { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
