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
        
        response.success = modules.success;
        response.result = _mapper.Map<List<ModuleInventoryDto>>(modules.result);
        response.errorMessage = modules.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<ModuleInventoryDto>> GetModuleById(int moduleId)
    {
        var response = new ResponseModel<ModuleInventoryDto>();
        var module = await _unitOfWork.ModuleInventoryRepository.GetModule(moduleId);
        
        response.success = module.success;
        response.result = _mapper.Map<ModuleInventoryDto>(module.result);
        response.errorMessage = module.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> CreateModule(ModuleInventoryDto module)
    {
        var response = new ResponseModel<int>();
        var moduleEntity = _mapper.Map<ModuleInventory>(module);
        var result = await _unitOfWork.ModuleInventoryRepository.CreateModule(moduleEntity);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> UpdateModule(ModuleInventoryDto module)
    {
        var response = new ResponseModel<int>();
        var moduleEntity = _mapper.Map<ModuleInventory>(module);
        var result = await _unitOfWork.ModuleInventoryRepository.UpdateModule(moduleEntity);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }

    public async Task<ResponseModel<int>> DeleteModule(int moduleId)
    {
        var response = new ResponseModel<int>();
        var result = await _unitOfWork.ModuleInventoryRepository.DeleteModule(moduleId);
        
        response.success = result.success;
        response.result = result.result;
        response.errorMessage = result.errorMessage;
        
        return response;
    }
}