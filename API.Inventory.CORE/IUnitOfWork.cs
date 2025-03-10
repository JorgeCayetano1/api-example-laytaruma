using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public interface IUnitOfWork
    {
        IUserInventoryRepository UserInventoryRepository { get; }
        IRoleInventoryRepository RoleInventoryRepository { get; }
        IModuleInventoryRepository ModuleInventoryRepository { get; }
    }
}
