using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using KRS.DataAccess.IInfrastructure;
using KRS.DataAccess.Infrastructure;
using KRS.Model;

namespace KRS.DataAccess.Repositories
{
    public class DeliveryRepository : RepositoryBase<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            var deliveries = DataContext.Deliveries.Include(d => d.Customer);
            return deliveries.ToList();
        }

    }
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        IEnumerable<Delivery> GetDeliveries();
    }

}