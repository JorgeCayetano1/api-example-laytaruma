using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Repositories.Interface
{
    public interface IUserInventoryRepository
    {
        Task<ResponseModel<List<UserInventory>>> GetAllUsers();
        Task<ResponseModel<UserInventory>> GetUser(int userId);
        Task<ResponseModel<int>> CreateUser(UserInventory user);
        Task<ResponseModel<int>> UpdateUser(UserInventory user);
        Task<ResponseModel<int>> DeleteUser(int userId);

    }
}
