using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Services.Interface
{
    public interface IUserInventoryService
    {
        Task<ResponseModel<List<UserInventoryDto>>> GetAllUsers();
        Task<ResponseModel<UserInventoryDto>> GetUserById(int userId);
        Task<ResponseModel<int>> CreateUser(UserInventoryDto user);
        Task<ResponseModel<int>> UpdateUser(UserInventoryDto user);
        Task<ResponseModel<int>> DeleteUser(int userId);
    }
}
