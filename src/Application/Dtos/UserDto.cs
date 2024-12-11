using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
        public StatusUser Status { get; set; } = StatusUser.Active;
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Status = user.Status,
            };
        }

        public static IEnumerable<UserDto> ToListDto(IEnumerable<User> users)
        {
            var list = new List<UserDto>();
            foreach (var item in users)
            {
                list.Add(ToDto(item));
            }
            return list;
        }
    }
}
