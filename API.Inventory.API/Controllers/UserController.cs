using API.Inventory.CORE;
using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _unitOfWork.UserRepository.GetAllUsers();
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
            var response = await _unitOfWork.UserRepository.GetUser(userId);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var response = await _unitOfWork.UserRepository.CreateUser(user);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
