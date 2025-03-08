using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<ResponseModel> GetAllUsers();
        Task<ResponseModel> GetUser(int userId);
        Task<ResponseModel> CreateUser(User user);
        Task<ResponseModel> UpdateUser(User user);
        Task<ResponseModel> DeleteUser(int userId);

    }
}
