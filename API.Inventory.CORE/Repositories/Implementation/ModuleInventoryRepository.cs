using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Common.Core.Services;
using Microsoft.Data.SqlClient;

namespace API.Inventory.CORE.Repositories.Implementation;

public class ModuleInventoryRepository : IModuleInventoryRepository
{
    private readonly IDbContext _dbContext;
    
    public ModuleInventoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ModuleInventory>> GetAllModules()
    {
        var sql = "Inventory.GetModules";
        
        var dataTableResponse = await _dbContext.QueryAsync(sql);
        var modules = dataTableResponse.TableToList<ModuleInventory>();
        
        return modules;
    }

    public async Task<ModuleInventory?> GetModule(int moduleId)
    {
        var sql = "Inventory.GetModuleById";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleId", moduleId)
        };
        
        var dataTableResult = await _dbContext.QueryAsync(sql, parameters);
        var module = dataTableResult.TableToList<ModuleInventory>().FirstOrDefault();
        
        return module;
    }

    public async Task<int> CreateModule(ModuleInventory module)
    {
        var sql = "Inventory.CreateModule";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleName", module.MODULE_NAME),
            new SqlParameter("@ModuleDescription", module.MODULE_DESCRIPTION)
        };
        
        var result = await _dbContext.ExecuteAsync(sql, parameters);
        
        return result;
    }

    public async Task<int> UpdateModule(ModuleInventory module)
    {
        var sql = "Inventory.UpdateModule";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleId", module.MODULE_INVENTORY_ID),
            new SqlParameter("@ModuleName", module.MODULE_NAME),
            new SqlParameter("@ModuleDescription", module.MODULE_DESCRIPTION)
        };
        
        var result = await _dbContext.ExecuteAsync(sql, parameters);
        
        return result;
    }

    public async Task<int> DeleteModule(int moduleId)
    {
        var sql = "Inventory.DeleteModule";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleId", moduleId)
        };
        
        var result = await _dbContext.ExecuteAsync(sql, parameters);
        
        return result;
    }
}