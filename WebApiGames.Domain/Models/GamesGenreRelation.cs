namespace WebApiGames.Domain.Models
{
    public class GamesGenreRelation
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int GenreId { get; set; }
    }
}
