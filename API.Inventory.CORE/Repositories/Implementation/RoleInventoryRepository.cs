using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Common.Core.Services;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Implementation;

public class RoleInventoryRepository : IRoleInventoryRepository
{
    private readonly IDbContext _dbContext;
    
    public RoleInventoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<RoleInventory>> GetAllRoles()
    {
        var sql = "Inventory.GetRoles";
        
        var dataTableResponse = await _dbContext.QueryAsync(sql);
        var roles = dataTableResponse.TableToList<RoleInventory>();
        
        return roles;
    }

    public async Task<RoleInventory?> GetRole(int roleId)
    {
        var sql = "Inventory.GetRoleById";
        
        var parameters = new[]
        {
            new SqlParameter("@RoleId", roleId)
        };
        
        var dataTableResult = await _dbContext.QueryAsync(sql, parameters);
        var role = dataTableResult.TableToList<RoleInventory>().FirstOrDefault();
        
        return role;
    }

    public async Task<int> CreateRole(RoleInventory role)
    {
        var sql = "Inventory.CreateRole";
        
        var parameters = new[]
        {
            new SqlParameter("@RoleName", role.ROLE_NAME)
        };
        
        var response = await _dbContext.ExecuteAsync(sql, parameters);
        
        return response;
    }

    public async Task<int> UpdateRole(RoleInventory role)
    {
        var sql = "Inventory.UpdateRole";
        
        var parameters = new[]
        {
            new SqlParameter("@RoleId", role.ROLE_INVENTORY_ID),
            new SqlParameter("@RoleName", role.ROLE_NAME)
        };
        
        var response = await _dbContext.ExecuteAsync(sql, parameters);
        
        return response;
    }

    public async Task<int> DeleteRole(int roleId)
    {
        var sql = "Inventory.DeleteRole";
        
        var parameters = new[]
        {
            new SqlParameter("@RoleId", roleId)
        };
        
        var response = await _dbContext.ExecuteAsync(sql, parameters);
        
        
        return response;
    }
}