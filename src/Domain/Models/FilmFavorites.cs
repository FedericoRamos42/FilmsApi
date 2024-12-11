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
        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; } = new Favorite();
        public int MovieId { get; set; }
        public Film Movie { get; set; } = new Film();
        public DateTime CreatedAt { get; set; }

       
    }
}
