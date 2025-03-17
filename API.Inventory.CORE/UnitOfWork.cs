using API.Inventory.CORE.Repositories.Connection;
using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext DbContext { get; }
        public IUserInventoryRepository UserInventoryRepository { get; }
        public IRoleInventoryRepository RoleInventoryRepository { get; }
        public IModuleInventoryRepository ModuleInventoryRepository { get; }

        public UnitOfWork(
            IUserInventoryRepository userInventoryRepository,
            IRoleInventoryRepository roleInventoryRepository,
            IModuleInventoryRepository moduleInventoryRepository,
            IDbContext dbContext
            )
        {
            UserInventoryRepository = userInventoryRepository;
            RoleInventoryRepository = roleInventoryRepository;
            ModuleInventoryRepository = moduleInventoryRepository;
            DbContext = dbContext;
        }
    }
}
