using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Common.Core.Services;
using API.Inventory.CORE.Entities;

namespace API.Inventory.CORE.Repositories.Implementation
{
    public class UserInventoryInventoryRepository : IUserInventoryRepository
    {
       
        private readonly IDbContext _dbContext;
        
        public UserInventoryInventoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<ResponseModel<List<UserInventory>>> GetAllUsers()
        {
            var response = new ResponseModel<List<UserInventory>>();
            var sql = "Inventory.GetUsers";
            
            var dataTableResponse = await _dbContext.QueryAsync(sql);
            var users = dataTableResponse.result.TableToList<UserInventory>();
            
            response.success = true;
            response.result = users;
            return response;
        }
        
        public async Task<ResponseModel<UserInventory>> GetUser(int userId)
        {
            var response = new ResponseModel<UserInventory>();
            var sql = "Inventory.GetUserById";
            
            var parameters = new[]
            {
                new SqlParameter("@UserId", userId)
            };
            
            var dataTableResult = await _dbContext.QueryAsync(sql, parameters);
            var user = dataTableResult.result.TableToList<UserInventory>().FirstOrDefault();
            
            if (user != null)
            {
                response.success = true;
                response.result = user;
            }
            else
            {
                response.success = false;
                response.errorMessage = "User not found";
            }
            
            return response;
        }
        
        public async Task<ResponseModel<int>> CreateUser(UserInventory user)
        {
            var sql = "Inventory.CreateUser";
            
            var parameters = new[]
            {
                new SqlParameter("@UserName", user.USER_NAME),
                new SqlParameter("@UserEmail", user.USER_EMAIL),
                new SqlParameter("@UserPassword", user.USER_PASSWORD),
            };
            
            var response = await _dbContext.ExecuteAsync(sql, parameters);

            return response;

        }
        
        public async Task<ResponseModel<int>> UpdateUser(UserInventory user)
        {
            var sql = "Inventory.UpdateUser";
            
            var parameters = new[]
            {
                new SqlParameter("@UserId", user.USER_INVENTORY_ID),
                new SqlParameter("@UserName", user.USER_NAME),
                new SqlParameter("@UserEmail", user.USER_EMAIL),
            };
            
            var response = await _dbContext.ExecuteAsync(sql, parameters);

            return response;
        }
        
        public async Task<ResponseModel<int>> DeleteUser(int userId)
        {
            var sql = "Inventory.DeleteUser";
            
            var parameters = new[]
            {
                new SqlParameter("@UserId", userId)
            };
            
            var response = await _dbContext.ExecuteAsync(sql, parameters);
            
            return response;
        }

    }
}
