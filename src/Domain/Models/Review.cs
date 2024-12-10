using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Comment { get; set; } = string.Empty;
        public int Raiting { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public int FilmId { get; set; }
        public Film Film { get; set; }= new Film();

        public Review(string comment,int raiting,int filmId,int userId)
        {
            Comment = comment;
            Raiting = raiting; 
            FilmId = filmId;
            UserId = userId;
        }

    }
}
