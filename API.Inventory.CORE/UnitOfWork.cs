using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly DbTransaction _transaction;
        //private bool _disposed = false;
        //private readonly SqlConnectionCore _connection;

        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            //SqlConnectionCore connection, 
            //SqlTransaction transaction, 
            IUserRepository userRepository
            )
        {
            //_connection = connection;
            //_transaction = transaction;
            //_connection.GetOpenConnection();
            //_transaction = _connection.BeginTransaction();
            UserRepository = userRepository;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        //public void Commit()
        //{
        //    _transaction.Commit();
        //}
        //public void Rollback()
        //{
        //    _transaction.Rollback();
        //}

        //public void Dispose()
        //{
        //    dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //private void dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            if (_transaction != null)
        //            {
        //                _transaction.Dispose();
        //            }
        //            if (disposing)
        //            {
        //                _transaction?.Dispose();
        //                _connection?.CloseConnection();
        //            }
        //        }
        //        _disposed = true;
        //    }
        //}


    }
}
