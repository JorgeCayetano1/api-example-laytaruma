using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;

namespace API.Inventory.CORE.Repositories.Interface;

public interface IRoleInventoryRepository
{
    Task<ResponseModel<List<RoleInventory>>> GetAllRoles();
    Task<ResponseModel<RoleInventory>> GetRole(int roleId);
    Task<ResponseModel<int>> CreateRole(RoleInventory role);
    Task<ResponseModel<int>> UpdateRole(RoleInventory role);
    Task<ResponseModel<int>> DeleteRole(int roleId);
}