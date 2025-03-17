using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;

namespace API.Inventory.CORE.Repositories.Interface;

public interface IRoleInventoryRepository
{
    Task<List<RoleInventory>> GetAllRoles();
    Task<RoleInventory?> GetRole(int roleId);
    Task<int> CreateRole(RoleInventory role);
    Task<int> UpdateRole(RoleInventory role);
    Task<int> DeleteRole(int roleId);
}