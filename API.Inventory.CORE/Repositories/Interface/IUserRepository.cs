using API.Inventory.CORE.Models;
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
    }
}
