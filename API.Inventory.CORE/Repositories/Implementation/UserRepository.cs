using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.Data.SqlClient;
using API.Inventory.CORE.Models.DTO;
using Common.Core.Services;
using API.Inventory.CORE.Entities;

namespace API.Inventory.CORE.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
       
        private readonly IDbContext _dbContext;
        
        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<ResponseModel> GetAllUsers()
        {
            var response = new ResponseModel();
            var sql = @"SELECT 
                           [USER_INVENTORY_ID]
                          ,[USER_NAME]
                          ,[USER_EMAIL]
                          ,[USER_PASSWORD]
                          ,[CREATED_BY]
                          ,[UPDATED_BY]
                      FROM [BDINTEGRA].[Inventory].[USER_INVENTORY];";
            
            var dataTable = await _dbContext.QueryAsync(sql);
            var users = dataTable.TableToList<User>();
            
            response.success = true;
            response.result = users;
            return response;
        }
        
        public async Task<ResponseModel> GetUser(int userId)
        {
            var response = new ResponseModel();
            var sql = @"SELECT 
                           [USER_INVENTORY_ID]
                          ,[USER_NAME]
                          ,[USER_EMAIL]
                          ,[USER_PASSWORD]
                          ,[CREATED_BY]
                          ,[UPDATED_BY]
                      FROM [BDINTEGRA].[Inventory].[USER_INVENTORY]
                      WHERE [USER_INVENTORY_ID] = @UserId;";
            
            var parameters = new[]
            {
                new SqlParameter("@UserId", userId)
            };
            
            var dataTable = await _dbContext.QueryAsync(sql, parameters);
            var user = dataTable.TableToList<User>().FirstOrDefault();
            
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
        
        public async Task<ResponseModel> CreateUser(User user)
        {
            var response = new ResponseModel();
            var sql = "[Inventory].[sp_CrearUsuario]";
            
            var parameters = new[]
            {
                new SqlParameter("@USER_NAME", user.USER_NAME),
                new SqlParameter("@USER_EMAIL", user.USER_EMAIL),
                new SqlParameter("@USER_PASSWORD", user.USER_PASSWORD),
                new SqlParameter("@CREATED_BY", DateTime.Now),
                new SqlParameter("@UPDATED_BY", DateTime.Now)
            };
            
            var rowsAffected = await _dbContext.ExecuteAsync(sql, parameters);
            
            if (rowsAffected == 0)
            {
                response.success = false;
                response.errorMessage = "User not created";
                return response;
            }
            
            response.success = true;
            response.successMessage = "User created successfully";
            
            return response;
        }
        
        public async Task<ResponseModel> UpdateUser(User user)
        {
            var response = new ResponseModel();
            var sql = "[Inventory].[sp_ActualizarUsuario]";
            
            var parameters = new[]
            {
                new SqlParameter("@USER_INVENTORY_ID", user.USER_INVENTORY_ID),
                new SqlParameter("@USER_NAME", user.USER_NAME),
                new SqlParameter("@USER_EMAIL", user.USER_EMAIL),
                new SqlParameter("@USER_PASSWORD", user.USER_PASSWORD),
                new SqlParameter("@UPDATED_BY", DateTime.Now)
            };
            
            var rowsAffected = await _dbContext.ExecuteAsync(sql, parameters);
            if (rowsAffected == 0)
            {
                response.success = false;
                response.errorMessage = "User not updated";
                return response;
            }
            
            response.success = true;
            response.successMessage = "User updated successfully";
            
            return response;
        }
        
        public Task<ResponseModel> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
