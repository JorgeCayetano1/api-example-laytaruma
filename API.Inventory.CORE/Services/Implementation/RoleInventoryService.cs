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
        
        response.success = roles.success;
        response.result = _mapper.Map<List<RoleInventoryDto>>(roles.result);
        response.errorMessage = roles.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<RoleInventoryDto>> GetRoleById(int roleId)
    {
        var response = new ResponseModel<RoleInventoryDto>();
        var role = await _unitOfWork.RoleInventoryRepository.GetRole(roleId);
        
        response.success = role.success;
        response.result = _mapper.Map<RoleInventoryDto>(role.result);
        response.errorMessage = role.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> CreateRole(RoleInventoryDto role)
    {
        var response = new ResponseModel<int>();
        var roleEntity = _mapper.Map<RoleInventory>(role);
        var result = await _unitOfWork.RoleInventoryRepository.CreateRole(roleEntity);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> UpdateRole(RoleInventoryDto role)
    {
        var response = new ResponseModel<int>();
        var roleEntity = _mapper.Map<RoleInventory>(role);
        var result = await _unitOfWork.RoleInventoryRepository.UpdateRole(roleEntity);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> DeleteRole(int roleId)
    {
        var response = new ResponseModel<int>();
        var result = await _unitOfWork.RoleInventoryRepository.DeleteRole(roleId);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }
}