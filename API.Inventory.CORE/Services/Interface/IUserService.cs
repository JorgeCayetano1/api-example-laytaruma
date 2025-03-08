using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Services.Interface
{
    public interface IUserService
    {
        Task<ResponseModel> GetAllUsers();
        Task<ResponseModel> GetUserById(int userId);
        Task<ResponseModel> CreateUser(UserDto user);
        Task<ResponseModel> UpdateUser(UserDto user);
    }
}
