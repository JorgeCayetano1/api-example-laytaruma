using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Helpers;
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
        private readonly ExcelService _excelService;

        public UserInventoryService(IUnitOfWork unitOfWork, IMapper mapper, ExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _excelService = excelService;
        }

        public async Task<ResponseModel<List<UserInventoryDto>>> GetAllUsers()
        {
            var response = new ResponseModel<List<UserInventoryDto>>();
            var users = await _unitOfWork.UserInventoryRepository.GetAllUsers();
            
            response.result = _mapper.Map<List<UserInventoryDto>>(users);
            response.success = true;
            response.successMessage = "Successfully retrieved users";
            
            return response;
        }
        
        public async Task<ResponseModel<UserInventoryDto>> GetUserById(int userId)
        {
            var response = new ResponseModel<UserInventoryDto>();
            var user = await _unitOfWork.UserInventoryRepository.GetUser(userId);
            
            var userDto = _mapper.Map<UserInventoryDto>(user);
            response.result = userDto;
            response.success = true;
            response.successMessage = "Successfully retrieved user";
            
            return response;
        }
        
        public async Task<ResponseModel<MemoryStream>> ExportUsers()
        {
            var response = new ResponseModel<MemoryStream>();
            var users = await _unitOfWork.UserInventoryRepository.GetAllUsers();
            var usersDto = _mapper.Map<List<UserInventoryDto>>(users);
            
            var result = _excelService.ExportExcel(usersDto, "Users");
            if (result == null)
            {
                response.success = false;
                response.errorMessage = "Error exporting users";
                return response;
            }
            
            response.success = true;
            response.result = result;
            response.successMessage = "Users.xlsx";
            
            return response;
        }
        
        public async Task<ResponseModel<MemoryStream>> ImportUsers(List<Stream> fileStreams)
        {
            var response = new ResponseModel<MemoryStream>();
            var usersDto = await ExcelService.ImportExcelAsync<UserInventoryDto>(fileStreams);
            if (usersDto == null)
            {
                response.success = false;
                response.errorMessage = "Error importing users";
                return response;
            }
            
            var users = _mapper.Map<List<UserInventory>>(usersDto);
            await _unitOfWork.DbContext.BeginTransactionAsync();
            foreach (var user in users)
            {
                var result = await _unitOfWork.UserInventoryRepository.CreateUser(user);
                if (result != 0) continue;
                await _unitOfWork.DbContext.RollbackTransactionAsync();
                response.success = false;
                response.errorMessage = "Error importing users";
                return response;
            }
            
            await _unitOfWork.DbContext.CommitTransactionAsync();
            response.success = true;
            response.successMessage = "Successfully imported users";
            
            return response;
        }
        
        public async Task<ResponseModel<int>> CreateUser(UserInventoryDto userDto)
        {
            var response = new ResponseModel<int>();
            var user = _mapper.Map<UserInventory>(userDto);
            
            await _unitOfWork.DbContext.BeginTransactionAsync();
            var result = await _unitOfWork.UserInventoryRepository.CreateUser(user);
            if (result == 0)
            {
                await _unitOfWork.DbContext.RollbackTransactionAsync();
                response.success = false;
                response.errorMessage = "Error creating user";
                return response;
            }
            
            await _unitOfWork.DbContext.CommitTransactionAsync();
            response.success = true;
            response.result = result;
            response.successMessage = "Successfully created user";
            
            return response;
        }
        
        public async Task<ResponseModel<int>> UpdateUser(UserInventoryDto userDto)
        {
            var response = new ResponseModel<int>();
            var findUser = await _unitOfWork.UserInventoryRepository.GetUser(userDto.UserInventoryId);
            if (findUser == null)
            {
                response.success = false;
                response.errorMessage = "User not found";
                return response;
            }
            
            var userProfile = _mapper.Map<UserInventory>(userDto);
            
            await _unitOfWork.DbContext.BeginTransactionAsync();
            var result = await _unitOfWork.UserInventoryRepository.UpdateUser(userProfile);
            if (result == 0)
            {
                await _unitOfWork.DbContext.RollbackTransactionAsync();
                response.success = false;
                response.errorMessage = "Error updating user";
                return response;
            }
            
            await _unitOfWork.DbContext.CommitTransactionAsync();
            response.success = true;
            response.result = result;
            response.successMessage = "Successfully updated user";
            
            return response;
        }
        
        public async Task<ResponseModel<int>> DeleteUser(int userId)
        {
            var response = new ResponseModel<int>();
            var findUser = await _unitOfWork.UserInventoryRepository.GetUser(userId);
            if (findUser == null)
            {
                response.success = false;
                response.errorMessage = "User not found";
                return response;
            }
            
            await _unitOfWork.DbContext.BeginTransactionAsync();
            var result = await _unitOfWork.UserInventoryRepository.DeleteUser(userId);
            if (result == 0)
            {
                await _unitOfWork.DbContext.RollbackTransactionAsync();
                response.success = false;
                response.errorMessage = "Error deleting user";
                return response;
            }
            
            await _unitOfWork.DbContext.CommitTransactionAsync();
            response.success = true;
            response.result = result;
            response.successMessage = "Successfully deleted user";
            
            return response;
        }
    }
}
