using Microsoft.EntityFrameworkCore;
using WebApiGames.Data.Models;

namespace WebApiGames.Data
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GamesGenreRelation> GamesGenreRelations { get; set; }

        public DbSet<DeveloperStudio> DeveloperStudios { get; set; }
    }
}
