using API.Inventory.CORE.Repositories.Interface;

namespace API.Inventory.CORE
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public UnitOfWork(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
    }
}
