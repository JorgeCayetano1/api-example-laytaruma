using API.Inventory.CORE.Models;
using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Inventory.CORE.Models.DTO;
using Common.Core.Services;
using API.Inventory.CORE.Entities;

namespace API.Inventory.CORE.Repositories.Implementation
{
    public class UserRepository : Repository, IUserRepository
    {
        private readonly SqlConnection _context;
        private readonly SqlTransaction _transaction;

        public UserRepository(SqlConnection context, SqlTransaction transaction) : base(context, transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public async Task<ResponseModel> GetAllUsers()
        {
            ResponseModel response = new ResponseModel();
            List<UserDto> users = new List<UserDto>();

            using (var command = CreateCommand())
            {
                command.CommandText = @"SELECT 
                                           [USER_INVENTORY_ID]
                                          ,[USER_NAME]
                                          ,[USER_EMAIL]
                                          ,[USER_PASSWORD]
                                          ,[CREATED_BY]
                                          ,[UPDATED_BY]
                                      FROM [BDINTEGRA].[Inventory].[USER_INVENTORY];";
                command.CommandType = CommandType.Text; // Cambiado a CommandType.Text

                using (var reader = await command.ExecuteReaderAsync())
                {

                    ReflectionService.ReaderToList<User>(reader);
                }
            }

            response.success = true;
            response.result = users;
            return response;
        }

        public async Task<ResponseModel> GetUser(int userId)
        {
            ResponseModel response = new ResponseModel();
            UserDto user = null;

            using (var command = CreateCommand())
            {
                command.CommandText = @"SELECT 
                                           [USER_INVENTORY_ID]
                                          ,[USER_NAME]
                                          ,[USER_EMAIL]
                                          ,[USER_PASSWORD]
                                          ,[CREATED_BY]
                                          ,[UPDATED_BY]
                                      FROM [BDINTEGRA].[Inventory].[USER_INVENTORY]
                                      WHERE [USER_NAME] = @UserId;";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    //if (await reader.ReadAsync())
                    //{
                    //    user = new UserDto
                    //    {
                    //        UserId = reader.GetInt32(0),
                    //        Nombre = reader.GetString(1),
                    //        Password = reader.GetString(2),
                    //        CreatedAt = reader.GetDateTime(3),
                    //        UpdatedAt = reader.GetDateTime(4)
                    //    };
                    //}

                    ReflectionService.ReaderToList<User>(reader);
                }
            }

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

        public async Task<ResponseModel> CreateUser(UserDto user)
        {
            //try
            //{
            //    ResponseModel response = new ResponseModel();
            //    using (var command = CreateCommand())
            //    {
            //        command.CommandText = "[Inventory].[sp_CrearUsuario]";
            //        command.CommandType = CommandType.StoredProcedure;
            //        //SqlParameter param;
            //        //param = command.Parameters.Add("@USER_NAME", SqlDbType.VarChar);
            //        //param.Value = user.Nombre;
            //        //command.Parameters.Add("@USER_EMAIL", SqlDbType.VarChar);
            //        //param.Value = user.Email;
            //        //command.Parameters.Add("@USER_PASSWORD", SqlDbType.VarChar);
            //        //param.Value = user.Password;
            //        //command.Parameters.Add("@CREATED_BY", SqlDbType.DateTime);
            //        //param.Value = DateTime.Now;
            //        //command.Parameters.Add("@UPDATED_BY", SqlDbType.DateTime);
            //        //param.Value = DateTime.Now;

            //        command.Parameters.AddWithValue("@USER_NAME", user.Nombre);
            //        command.Parameters.AddWithValue("@USER_EMAIL", user.Email);
            //        command.Parameters.AddWithValue("@USER_PASSWORD", user.Password);
            //        command.Parameters.AddWithValue("@CREATED_BY", DateTime.Now);
            //        command.Parameters.AddWithValue("@UPDATED_BY", DateTime.Now);


            //        // Imprimir el comando SQL y sus parámetros
            //        //Console.WriteLine("SQL Command: " + command.CommandText);
            //        //foreach (SqlParameter param in command.Parameters)
            //        //{
            //        //    Console.WriteLine($"{param.ParameterName}: {param.Value}");
            //        //}

            //        var rowsAffected = await command.ExecuteNonQueryAsync();
            //        if (rowsAffected <= 0)
            //        {
            //            response.success = false;
            //            response.errorMessage = "User not created";
            //            return response;
            //        }

            //        response.success = true;
            //        response.successMessage = "User created successfully";


            //        return response;
            //    }
            //}
            //catch (Exception ex) 
            //{
            //    ResponseModel response = new ResponseModel();
            //    response.success = false;
            //    response.errorMessage = ex.Message;
            //    return response;
            //}

            try
            {
                ResponseModel response = new ResponseModel();
                using (var command = CreateCommand())
                {
                    command.CommandText = "[Inventory].[sp_CrearUsuario]";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@USER_NAME", user.Nombre);
                    command.Parameters.AddWithValue("@USER_EMAIL", user.Email);
                    command.Parameters.AddWithValue("@USER_PASSWORD", user.Password);
                    command.Parameters.AddWithValue("@CREATED_BY", DateTime.Now);
                    command.Parameters.AddWithValue("@UPDATED_BY", DateTime.Now);

                    // Imprimir el comando SQL y sus parámetros para depuración
                    Console.WriteLine("SQL Command: " + command.CommandText);
                    foreach (SqlParameter param in command.Parameters)
                    {
                        Console.WriteLine($"{param.ParameterName}: {param.Value}");
                    }

                    //var rowsAffected = await command.ExecuteNonQueryAsync();
                    //if (rowsAffected <= 0)
                    //{
                    //    response.success = false;
                    //    response.errorMessage = "User not created";
                    //    return response;
                    //}

                    using (var reader = await command.ExecuteReaderAsync())
                    response.success = true;
                    response.successMessage = "User created successfully";
                    return response;
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico de errores SQL
                ResponseModel response = new ResponseModel();
                response.success = false;
                response.errorMessage = $"SQL Error: {sqlEx.Message}";
                return response;
            }
            catch (Exception ex)
            {
                // Manejo general de errores
                ResponseModel response = new ResponseModel();
                response.success = false;
                response.errorMessage = ex.Message;
                return response;
            }
        }

        public Task<ResponseModel> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
