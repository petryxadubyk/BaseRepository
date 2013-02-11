using KRS.DataAccess.IInfrastructure;
using KRS.DataAccess.IRepositories;
using KRS.DataAccess.Infrastructure;
using KRS.Model;

namespace KRS.DataAccess.Repositories
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
