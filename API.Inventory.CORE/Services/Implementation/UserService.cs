using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Services.Interface;
using API.Inventory.CORE.Models.DTO;
using AutoMapper;

namespace API.Inventory.CORE.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel> GetAllUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users.result);
            return new ResponseModel { success = true, result = usersDto };
        }
        
        public async Task<ResponseModel> GetUserById(int userId)
        {
            return await _unitOfWork.UserRepository.GetUser(userId);
        }
        
        public async Task<ResponseModel> CreateUser(UserDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _unitOfWork.UserRepository.CreateUser(userEntity);
        }
        
        public async Task<ResponseModel> UpdateUser(UserDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _unitOfWork.UserRepository.UpdateUser(userEntity);
        }
    }
}
