using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGames.Domain.Models
{
    public class DeveloperStudio
    {
        public int Id { get; set; }
        
        public string StudioName { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
