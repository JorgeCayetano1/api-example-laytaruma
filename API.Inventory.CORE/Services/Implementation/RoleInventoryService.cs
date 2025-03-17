using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Services.Interface;
using AutoMapper;

namespace API.Inventory.CORE.Services.Implementation;

public class RoleInventoryService : IRoleInventoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public RoleInventoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseModel<List<RoleInventoryDto>>> GetAllRoles()
    {
        var response = new ResponseModel<List<RoleInventoryDto>>();
        var roles = await _unitOfWork.RoleInventoryRepository.GetAllRoles();
        
        response.success = true;
        response.result = _mapper.Map<List<RoleInventoryDto>>(roles);
        response.successMessage = "Successfully retrieved roles";

        return response;
    }

    public async Task<ResponseModel<RoleInventoryDto>> GetRoleById(int roleId)
    {
        var response = new ResponseModel<RoleInventoryDto>();
        var role = await _unitOfWork.RoleInventoryRepository.GetRole(roleId);
        
        response.result = _mapper.Map<RoleInventoryDto>(role);
        response.success = true;
        response.successMessage = "Successfully retrieved role";
        
        return response;
    }

    public async Task<ResponseModel<int>> CreateRole(RoleInventoryDto role)
    {
        var response = new ResponseModel<int>();
        var roleEntity = _mapper.Map<RoleInventory>(role);
        
        await _unitOfWork.DbContext.BeginTransactionAsync();
        var result = await _unitOfWork.RoleInventoryRepository.CreateRole(roleEntity);
        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error creating role";
            
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully created role";

        return response;
    }

    public async Task<ResponseModel<int>> UpdateRole(RoleInventoryDto role)
    {
        var response = new ResponseModel<int>();
        
        var findRole = await _unitOfWork.RoleInventoryRepository.GetRole(role.RoleInventoryId);
        if (findRole == null)
        {
            response.success = false;
            response.errorMessage = "Role not found";
            
            return response;
        }
        
        var roleProfile = _mapper.Map<RoleInventory>(role);
        
        await _unitOfWork.DbContext.BeginTransactionAsync();
        var result = await _unitOfWork.RoleInventoryRepository.UpdateRole(roleProfile);
        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error updating role";
            
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully updated role";
        
        return response;
    }

    public async Task<ResponseModel<int>> DeleteRole(int roleId)
    {
        var response = new ResponseModel<int>();
        var findRole = await _unitOfWork.RoleInventoryRepository.GetRole(roleId);
        if (findRole == null)
        {
            response.success = false;
            response.errorMessage = "Role not found";
            
            return response;
        }
        
        await _unitOfWork.DbContext.BeginTransactionAsync();
        var result = await _unitOfWork.RoleInventoryRepository.DeleteRole(roleId);
        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error deleting role";
            
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully deleted role";
        
        return response;
    }
}