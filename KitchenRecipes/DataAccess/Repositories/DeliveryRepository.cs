using System.Collections.Generic;
using System.Linq;
using DataAccess.Infrastructure;
using Infrastructure.DeliveryModels;
using System.Data.Entity;

namespace DataAccess.Repositories
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