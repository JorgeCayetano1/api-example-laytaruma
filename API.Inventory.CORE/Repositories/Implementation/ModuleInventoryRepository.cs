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
    
    public async Task<ResponseModel<List<ModuleInventory>>> GetAllModules()
    {
        var response = new ResponseModel<List<ModuleInventory>>();
        var sql = "Inventory.GetModules";
        
        var dataTableResponse = await _dbContext.QueryAsync(sql);
        var modules = dataTableResponse.result.TableToList<ModuleInventory>();
        
        response.success = true;
        response.result = modules;
        return response;
    }

    public async Task<ResponseModel<ModuleInventory>> GetModule(int moduleId)
    {
        var response = new ResponseModel<ModuleInventory>();
        var sql = "Inventory.GetModuleById";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleId", moduleId)
        };
        
        var dataTableResult = await _dbContext.QueryAsync(sql, parameters);
        var module = dataTableResult.result.TableToList<ModuleInventory>().FirstOrDefault();
        
        if (module != null)
        {
            response.success = true;
            response.result = module;
        }
        else
        {
            response.success = false;
            response.errorMessage = "Module not found";
        }
        
        return response;
    }

    public async Task<ResponseModel<int>> CreateModule(ModuleInventory module)
    {
        var sql = "Inventory.CreateModule";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleName", module.MODULE_NAME),
            new SqlParameter("@ModuleDescription", module.MODULE_DESCRIPTION),
            new SqlParameter("@CreatedAt", module.CREATED_AT),
            new SqlParameter("@UpdatedAt", module.UPDATED_AT),
            new SqlParameter("@DeletedAt", module.DELETED_AT)
        };
        
        var result = await _dbContext.ExecuteAsync(sql, parameters);
        
        return result;
    }

    public async Task<ResponseModel<int>> UpdateModule(ModuleInventory module)
    {
        var sql = "Inventory.UpdateModule";
        
        var parameters = new[]
        {
            new SqlParameter("@ModuleId", module.MODULE_INVENTORY_ID),
            new SqlParameter("@ModuleName", module.MODULE_NAME),
            new SqlParameter("@ModuleDescription", module.MODULE_DESCRIPTION),
            new SqlParameter("@UpdatedAt", module.UPDATED_AT)
        };
        
        var result = await _dbContext.ExecuteAsync(sql, parameters);
        
        return result;
    }

    public async Task<ResponseModel<int>> DeleteModule(int moduleId)
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