using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
        public StatusUser Status { get; set; } = StatusUser.Active;
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        public User(string name, string lastName, string email, string password, Role role)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
        }
        public User() { }

    }
}
