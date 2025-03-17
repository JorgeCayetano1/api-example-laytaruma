using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Repositories.Interface
{
    public interface IUserInventoryRepository
    {
        Task<List<UserInventory>> GetAllUsers();
        Task<UserInventory?> GetUser(int userId);
        Task<int> CreateUser(UserInventory user);
        Task<int> UpdateUser(UserInventory user);
        Task<int> DeleteUser(int userId);

    }
}
