using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var obj = await _userService.GetById(id);
            return Ok(obj);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userService.GetAll();
            return Ok(list);
        }
        [HttpPost]
        public async Task <IActionResult> CreateUser(UserCreateRequest request)
        {
            var obj = await _userService.CreateUser(request);
            return Ok(obj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var obj = await _userService.UpdateUser(id);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            var obj = await _userService.DeleteUser(id);
            return Ok(obj);
        }


    }
}
