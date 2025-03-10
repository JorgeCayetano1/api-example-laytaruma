using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Services.Interface;
using API.Inventory.CORE.Models.DTO;
using AutoMapper;

namespace API.Inventory.CORE.Services.Implementation
{
    public class UserInventoryService : IUserInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserInventoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<UserInventoryDto>>> GetAllUsers()
        {
            var users = await _unitOfWork.UserInventoryRepository.GetAllUsers();
            var usersDto = _mapper.Map<List<UserInventoryDto>>(users.result);
            return new ResponseModel<List<UserInventoryDto>> { success = true, result = usersDto };
        }
        
        public async Task<ResponseModel<UserInventoryDto>> GetUserById(int userId)
        {
            var user = await _unitOfWork.UserInventoryRepository.GetUser(userId);
            var userDto = _mapper.Map<UserInventoryDto>(user.result);
            return new ResponseModel<UserInventoryDto> { success = true, result = userDto };
        }
        
        public async Task<ResponseModel<int>> CreateUser(UserInventoryDto user)
        {
            var userDto = _mapper.Map<UserInventory>(user);
            var response = await _unitOfWork.UserInventoryRepository.CreateUser(userDto);
            return response;
        }
        
        public async Task<ResponseModel<int>> UpdateUser(UserInventoryDto userDto)
        {
            var userResponse = await _unitOfWork.UserInventoryRepository.GetUser(userDto.UserInventoryId);
            
            if (!userResponse.success)
                return new ResponseModel<int> { success = false, errorMessage = "User not found" };
            
            var userMapper = _mapper.Map<UserInventory>(userDto);
            var response = await _unitOfWork.UserInventoryRepository.UpdateUser(userMapper);
            return response;
        }
        
        public async Task<ResponseModel<int>> DeleteUser(int userId)
        {
            var user = await _unitOfWork.UserInventoryRepository.GetUser(userId);
            
            if (!user.success)
                return new ResponseModel<int> { success = false, errorMessage = "User not found" };
            
            var response = await _unitOfWork.UserInventoryRepository.DeleteUser(userId);
            return response;
        }
    }
}
