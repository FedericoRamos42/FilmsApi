using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Duration { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(150)")]
        public string Img { get; set; } = string.Empty;
        public decimal AverageRaiting { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Review> ReviewList { get; set; } = new List<Review>();
        public List<FilmFavorites> filmFavorites { get; set; } = new List<FilmFavorites>();


        public Film(string title, int year, int duration, string description, int genreId, string img, decimal averageRaiting)
        {
            Title = title;
            Year = year;
            Duration = duration;
            Description = description;
            Img = img;
            AverageRaiting = averageRaiting;
            GenreId = genreId;
           
        }
        public Film()
        {
            
        }

        //public static decimal CalcAverage(List<Reviews> list)
        //{
        //    foreach (Review item in list)
        //}


    }
}
