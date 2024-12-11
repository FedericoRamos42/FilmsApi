using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(500)")] 
        public string Description { get; set; } = string.Empty ;
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<FilmFavorites> FilmFavorites { get; set; } = new List<FilmFavorites>(); 

        public Favorite(string name, string description, int userId)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            UserId = userId;
        }
        public Favorite()
        {
            
        }

    }
}
