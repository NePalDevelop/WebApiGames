using WebApiGames.Data.Models;
using System.Linq;

namespace WebApiGames.Data
{
    public class DbInitializer
    {
        public static void Initialize(GamesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any())
            {
                return;  
            }

            var studios = new DeveloperStudio[]
            {
                new DeveloperStudio{StudioName ="Blizzard"},
                new DeveloperStudio{StudioName ="Ninja Theory"},
                new DeveloperStudio{StudioName ="Hello Games"}
            };

            foreach (var s in studios)
            {
                context.DeveloperStudios.Add(s);
            }

            context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre {Name = "Shooter"},
                new Genre {Name = "Fighting"},
                new Genre {Name = "Strategy"}
            };

            foreach (var g in genres)
            {
                context.Genres.Add(g);
            }

            context.SaveChanges();

            var games = new Game[]
            {
                new Game {Name = "Tetris", DeveloperStudioId = 1},
                new Game {Name = "World of Tanks", DeveloperStudioId = 1},
                new Game {Name = "Dota2", DeveloperStudioId = 2},
                new Game {Name = "Civilization", DeveloperStudioId = 3},
                new Game {Name = "Doom", DeveloperStudioId = 3}
            };

            foreach (var g in games)
            {
                context.Games.Add(g);
            }

            context.SaveChanges();

            var relations = new GamesGenreRelation[]
            {
                new GamesGenreRelation {GameId = 1, GenreId = 1},
                new GamesGenreRelation {GameId = 1, GenreId = 2},
                new GamesGenreRelation {GameId = 2, GenreId = 1},
                new GamesGenreRelation {GameId = 2, GenreId = 2},
                new GamesGenreRelation {GameId = 3, GenreId = 1},
                new GamesGenreRelation {GameId = 3, GenreId = 3},
                new GamesGenreRelation {GameId = 4, GenreId = 2},
                new GamesGenreRelation {GameId = 4, GenreId = 3},
                new GamesGenreRelation {GameId = 5, GenreId = 1}
            };

            foreach (var r in relations)
            {
                context.GamesGenreRelations.Add(r);
            }

            context.SaveChanges();
        }
    }
}
