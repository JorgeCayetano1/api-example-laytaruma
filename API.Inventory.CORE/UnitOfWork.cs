using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserInventoryRepository UserInventoryRepository { get; }

        public UnitOfWork(IUserInventoryRepository userInventoryRepository)
        {
            UserInventoryRepository = userInventoryRepository;
        }
    }
}
