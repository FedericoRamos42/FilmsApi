using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;

        public List<Film> films { get; set; }= new List<Film>();

        public Genre(string name)
        {
            Name = name;
        }
    }
}
