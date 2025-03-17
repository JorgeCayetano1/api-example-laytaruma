using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Common.Core.Services;
using API.Inventory.CORE.Entities;

namespace API.Inventory.CORE.Repositories.Implementation
{
    public class UserInventoryRepository : IUserInventoryRepository
    {
       
        private readonly IDbContext _dbContext;
        
        public UserInventoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<UserInventory>> GetAllUsers()
        {
            var sql = "Inventory.GetUsers";
            
            var dataTableResponse = await _dbContext.QueryAsync(sql);
            var users = dataTableResponse.TableToList<UserInventory>();
            
            return users;
        }
        
        public async Task<UserInventory?> GetUser(int userId)
        {
            var response = new ResponseModel<UserInventory>();
            var sql = "Inventory.GetUserById";
            
            var parameters = new[]
            {
                new SqlParameter("@UserId", userId)
            };
            
            var dataTableResult = await _dbContext.QueryAsync(sql, parameters);
            var user = dataTableResult.TableToList<UserInventory>().FirstOrDefault();
            
            return user;
        }
        
        public async Task<int> CreateUser(UserInventory user)
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
        
        public async Task<int> UpdateUser(UserInventory user)
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
        
        public async Task<int> DeleteUser(int userId)
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
