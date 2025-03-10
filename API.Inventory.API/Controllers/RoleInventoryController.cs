using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleInventoryController : ControllerBase
    {
        private readonly IRoleInventoryService _roleInventoryService;
        
        public RoleInventoryController(IRoleInventoryService roleInventoryService)
        {
            _roleInventoryService = roleInventoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _roleInventoryService.GetAllRoles();
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpGet("{roleId:int}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var response = await _roleInventoryService.GetRoleById(roleId);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleInventoryDto role)
        {
            var response = await _roleInventoryService.CreateRole(role);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleInventoryDto role)
        {
            var response = await _roleInventoryService.UpdateRole(role);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpDelete("{roleId:int}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var response = await _roleInventoryService.DeleteRole(roleId);
            
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
    }
}
