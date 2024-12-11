using Application.Dtos;
using Application.Dtos.Request;
using Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetById(int id);
        Task<Result<List<UserDto>>> GetAll();
        Task <Result<UserDto>> CreateUser(UserCreateRequest user);
        Task <Result<UserDto>>DeleteUser(int id);
        Task<Result<UserDto>> UpdateUser(int id);

    }
}
