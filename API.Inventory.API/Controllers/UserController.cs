using API.Inventory.CORE;
using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Repositories.Interface;
using API.Inventory.CORE.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var response = await _userService.GetUserById(userId);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var response = await _userService.CreateUser(user);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            var response = await _userService.UpdateUser(user);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
