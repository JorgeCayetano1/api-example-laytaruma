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
            using (var command = CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users";
                command.CommandType = CommandType.StoredProcedure;

                using(var reader = await command.ExecuteReaderAsync())
                {
                    response.success = true;
                    response.result = reader;
                }

                return response;
            }
        }
    }
}
