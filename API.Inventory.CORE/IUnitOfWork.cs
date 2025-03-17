using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public interface IUnitOfWork
    {
        IDbContext DbContext { get; }
        IUserInventoryRepository UserInventoryRepository { get; }
        IRoleInventoryRepository RoleInventoryRepository { get; }
        IModuleInventoryRepository ModuleInventoryRepository { get; }
    }
}
