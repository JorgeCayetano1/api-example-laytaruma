﻿using API.Inventory.CORE;
using API.Inventory.CORE.Models.DTO;
using API.Inventory.CORE.Repositories.Interface;
using API.Inventory.CORE.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInventoryController : ControllerBase
    {
        private readonly IUserInventoryService _userInventoryService;

        public UserInventoryController(IUserInventoryService userInventoryService)
        {
            _userInventoryService = userInventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userInventoryService.GetAllUsers();
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var response = await _userInventoryService.GetUserById(userId);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [HttpGet("export")]
        public async Task<IActionResult> ExportUsers()
        {
            var response = await _userInventoryService.ExportUsers();
            if (!response.success) return BadRequest(response);
            
            return File(response.result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", response.successMessage);
        }

        [HttpPost("import-multiple")]
        public async Task<IActionResult> ImportMultiple(List<IFormFile> files)
        {
            var fileStreams = new List<Stream>();
            foreach (var file in files)
            {
                if (file.Length <= 0) continue;
                
                var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                fileStreams.Add(stream);
            }

            var response = await _userInventoryService.ImportUsers(fileStreams);
            if (!response.success) return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInventoryDto user)
        {
            var response = await _userInventoryService.CreateUser(user);
            if (!response.success)
                return BadRequest(response);
            
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserInventoryDto user)
        {
            var response = await _userInventoryService.UpdateUser(user);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var response = await _userInventoryService.DeleteUser(userId);
            if (response.success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
