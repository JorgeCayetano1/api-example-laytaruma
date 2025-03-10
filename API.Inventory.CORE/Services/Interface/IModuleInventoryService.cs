using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;

namespace API.Inventory.CORE.Services.Interface;

public interface IModuleInventoryService
{
    Task<ResponseModel<List<ModuleInventoryDto>>> GetAllModules();
    Task<ResponseModel<ModuleInventoryDto>> GetModuleById(int moduleId);
    Task<ResponseModel<int>> CreateModule(ModuleInventoryDto module);
    Task<ResponseModel<int>> UpdateModule(ModuleInventoryDto module);
    Task<ResponseModel<int>> DeleteModule(int moduleId);
}