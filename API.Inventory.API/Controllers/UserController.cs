using API.Inventory.CORE;
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
                return Ok(response.result);
            }
            return BadRequest(response);
        }
    }
}
