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
                                    user_id,
                                    nombre,
                                    password,
                                    created_at,
                                    updated_at 
                                FROM inventory.Users;";
                command.CommandType = CommandType.Text; // Cambiado a CommandType.Text

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new UserDto
                        {
                            UserId = reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Password = reader.IsDBNull(2) ? null : reader.GetString(2),
                            CreatedAt = reader.GetDateTime(3),
                            UpdatedAt = reader.GetDateTime(4)
                        });
                    }
                }
            }

            response.success = true;
            response.result = users;
            return response;
        }

    }
}
