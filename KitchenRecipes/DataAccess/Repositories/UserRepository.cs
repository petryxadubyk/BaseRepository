using DataAccess.Infrastructure;
using Infrastructure.DeliveryModels;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Customer>, IUserRepository
        {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IUserRepository : IRepository<Customer>
    {
    }    
}
