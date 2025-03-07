using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<ResponseModel> GetAllUsers();
        Task<ResponseModel> GetUser(int userId);
        Task<ResponseModel> CreateUser(UserDto user);
        Task<ResponseModel> UpdateUser(UserDto user);
        Task<ResponseModel> DeleteUser(int userId);

    }
}
