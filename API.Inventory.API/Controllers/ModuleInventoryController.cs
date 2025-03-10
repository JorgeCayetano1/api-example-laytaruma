using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Services.Implementation;
using API.Inventory.CORE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleInventoryController : ControllerBase
    {
        private readonly IModuleInventoryService  _moduleInventoryService;
        
        public ModuleInventoryController(IModuleInventoryService moduleInventoryService)
        {
            _moduleInventoryService = moduleInventoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllModules()
        {
            var response = await _moduleInventoryService.GetAllModules();
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpGet("{moduleId:int}")]
        public async Task<IActionResult> GetModuleById(int moduleId)
        {
            var response = await _moduleInventoryService.GetModuleById(moduleId);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateModule(ModuleInventoryDto module)
        {
            var response = await _moduleInventoryService.CreateModule(module);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateModule(ModuleInventoryDto module)
        {
            var response = await _moduleInventoryService.UpdateModule(module);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpDelete("{moduleId:int}")]
        public async Task<IActionResult> DeleteModule(int moduleId)
        {
            var response = await _moduleInventoryService.DeleteModule(moduleId);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
    }
}
