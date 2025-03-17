using API.Inventory.CORE.Entities;
using API.Inventory.CORE.Models;
using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Services.Interface;
using AutoMapper;

namespace API.Inventory.CORE.Services.Implementation;

public class ModuleInventoryService : IModuleInventoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ModuleInventoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponseModel<List<ModuleInventoryDto>>> GetAllModules()
    {
        var response = new ResponseModel<List<ModuleInventoryDto>>();
        var modules = await _unitOfWork.ModuleInventoryRepository.GetAllModules();
        
        response.result = _mapper.Map<List<ModuleInventoryDto>>(modules);
        response.success = true;
        response.successMessage = "Successfully retrieved modules";
        
        return response;
    }

    public async Task<ResponseModel<ModuleInventoryDto>> GetModuleById(int moduleId)
    {
        var response = new ResponseModel<ModuleInventoryDto>();
        var module = await _unitOfWork.ModuleInventoryRepository.GetModule(moduleId);
        
        response.result = _mapper.Map<ModuleInventoryDto>(module);
        response.success = true;
        response.successMessage = "Successfully retrieved module";
        
        return response;
    }

    public async Task<ResponseModel<int>> CreateModule(ModuleInventoryDto module)
    {
        var response = new ResponseModel<int>();
        var moduleProfile = _mapper.Map<ModuleInventory>(module);
        
        await _unitOfWork.DbContext.BeginTransactionAsync();
        
        var result = await _unitOfWork.ModuleInventoryRepository.CreateModule(moduleProfile);
        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error creating module";
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully created module";
        
        return response;
    }

    public async Task<ResponseModel<int>> UpdateModule(ModuleInventoryDto module)
    {
        var response = new ResponseModel<int>();
        var findModule = await _unitOfWork.ModuleInventoryRepository.GetModule(module.ModuleInventoryId);
        if (findModule == null)
        {
            response.success = false;
            response.errorMessage = "Module not found";
            return response;
        }
        
        var moduleProfile = _mapper.Map<ModuleInventory>(module);
        
        await _unitOfWork.DbContext.BeginTransactionAsync();
        
        var result = await _unitOfWork.ModuleInventoryRepository.UpdateModule(moduleProfile);

        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error updating module";
            
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully updated module";
        
        return response;
    }

    public async Task<ResponseModel<int>> DeleteModule(int moduleId)
    {
        var response = new ResponseModel<int>();
        var findModule = await _unitOfWork.ModuleInventoryRepository.GetModule(moduleId);
        if (findModule == null)
        {
            response.success = false;
            response.errorMessage = "Module not found";
            return response;
        }
        
        await _unitOfWork.DbContext.BeginTransactionAsync();

        var result = await _unitOfWork.ModuleInventoryRepository.DeleteModule(moduleId);
        if (result == 0)
        {
            await _unitOfWork.DbContext.RollbackTransactionAsync();
            response.success = false;
            response.errorMessage = "Error deleting module";
            
            return response;
        }
        
        await _unitOfWork.DbContext.CommitTransactionAsync();
        response.success = true;
        response.result = result;
        response.successMessage = "Successfully deleted module";
        return response;
    }
}