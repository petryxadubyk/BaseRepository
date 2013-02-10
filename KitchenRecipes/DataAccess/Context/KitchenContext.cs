using System.Data.Entity;
using DataAccess.Migrations;
using Infrastructure.DeliveryModels;

namespace DataAccess.Context
{
    public class KitchenContext : DbContext
    {
        static KitchenContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<KitchenContext, Configuration>());
        }
        public KitchenContext() : base("Name=DataAccess.Context.KitchenContext") { }
        private DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
