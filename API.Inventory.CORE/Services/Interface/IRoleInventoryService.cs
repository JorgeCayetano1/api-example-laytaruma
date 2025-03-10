using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Services.Interface;

public interface IRoleInventoryService
{
    Task<ResponseModel<List<RoleInventoryDto>>> GetAllRoles();
    Task<ResponseModel<RoleInventoryDto>> GetRoleById(int roleId);
    Task<ResponseModel<int>> CreateRole(RoleInventoryDto role);
    Task<ResponseModel<int>> UpdateRole(RoleInventoryDto role);
    Task<ResponseModel<int>> DeleteRole(int roleId);
}