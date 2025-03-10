using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;

namespace API.Inventory.CORE.Repositories.Interface;

public interface IModuleInventoryRepository
{
    Task<ResponseModel<List<ModuleInventory>>> GetAllModules();
    Task<ResponseModel<ModuleInventory>> GetModule(int moduleId);
    Task<ResponseModel<int>> CreateModule(ModuleInventory module);
    Task<ResponseModel<int>> UpdateModule(ModuleInventory module);
    Task<ResponseModel<int>> DeleteModule(int moduleId);
}