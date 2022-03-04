using System.Collections.Generic;

namespace WebApiGames.Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GamesGenreRelation> GamesRelaion { get; set; }
    }
}
