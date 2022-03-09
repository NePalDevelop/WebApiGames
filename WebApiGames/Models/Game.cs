using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiGames.Models
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(99, MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999)]
        public int StudioId { get; set; }

        public string DeveloperStudioName { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
