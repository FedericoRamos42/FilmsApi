using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FilmFavorites
    {

        public int Id { get; set; }
        public int FavoritesId { get; set; }
        public Favorites Favorites { get; set; } = new Favorites();
        public int MovieId { get; set; }
        public Film Movie { get; set; } = new Film();
        public DateTime CreatedAt { get; set; }

       
    }
}
