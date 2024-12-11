using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Application.Result;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<UserDto>> CreateUser(UserCreateRequest user)
        {
            if (user is null)
            {
                return Result<UserDto>.Failure("User is null");
            }

            var obj = new User(user.Name, user.Email, user.LastName, user.Password, user.Role);
            
            await _userRepository.Insert(obj);
            var dto = UserDto.ToDto(obj);
            return Result<UserDto>.Succes(dto); 
            
        }

        public async Task<Result<UserDto>> DeleteUser(int id)
        {
            var obj = await _userRepository.GetById(id);
            if (obj is null)
            {
                return Result<UserDto>.Failure($"User with id {id} does not exist");
            };

            await _userRepository.Delete(obj);
            var dto = UserDto.ToDto(obj);
            return Result<UserDto>.Succes(dto);
        }

        public async Task<Result<List<UserDto>>> GetAll()
        {
            var list = await _userRepository.GetAll(); 
            var listDto = UserDto.ToListDto(list); 

            return Result<List<UserDto>>.Succes(listDto.ToList());
        }

        public async Task<Result<UserDto>> GetById(int id)
        {
            var obj = await _userRepository.GetById(id);
            if (obj is null)
            {
                return Result<UserDto>.Failure($"User with id {id} does not exist");
            }
            var dto = UserDto.ToDto(obj);
            return Result<UserDto>.Succes(dto);
        }

        public async Task<Result<UserDto>> UpdateUser(int id)
        {
            var obj = await _userRepository.GetById(id);
            if (obj is null)
            {
                return Result<UserDto>.Failure($"User with id {id} does not exist");
            }
            obj.Status = Domain.Enums.StatusUser.Inactive;
            await _userRepository.Update(obj);
            var dto = UserDto.ToDto(obj);
            return Result<UserDto>.Succes(dto);

        }
    }
}
