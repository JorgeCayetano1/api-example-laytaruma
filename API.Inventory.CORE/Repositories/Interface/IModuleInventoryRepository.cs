using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;

namespace API.Inventory.CORE.Repositories.Interface;

public interface IModuleInventoryRepository
{
    Task<List<ModuleInventory>> GetAllModules();
    Task<ModuleInventory?> GetModule(int moduleId);
    Task<int> CreateModule(ModuleInventory module);
    Task<int> UpdateModule(ModuleInventory module);
    Task<int> DeleteModule(int moduleId);
}