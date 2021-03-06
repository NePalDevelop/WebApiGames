namespace WebApiGames.Data.Models
{
    public class GamesGenreRelation
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
