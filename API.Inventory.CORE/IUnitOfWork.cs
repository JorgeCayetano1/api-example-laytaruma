using API.Inventory.CORE.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Inventory.CORE
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        void Commit();
        void Rollback();
    }
}
