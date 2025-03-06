using API.Inventory.CORE.Models;
using API.Inventory.CORE.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAllUsers();
        }
    }
}
