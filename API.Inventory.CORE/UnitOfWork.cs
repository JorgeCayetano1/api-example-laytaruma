using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserInventoryRepository UserInventoryRepository { get; }
        public IRoleInventoryRepository RoleInventoryRepository { get; }
        public IModuleInventoryRepository ModuleInventoryRepository { get; }

        public UnitOfWork(
            IUserInventoryRepository userInventoryRepository,
            IRoleInventoryRepository roleInventoryRepository,
            IModuleInventoryRepository moduleInventoryRepository
            )
        {
            UserInventoryRepository = userInventoryRepository;
            RoleInventoryRepository = roleInventoryRepository;
            ModuleInventoryRepository = moduleInventoryRepository;
        }
    }
}
