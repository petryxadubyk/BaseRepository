using System.Data.Entity;
using KRS.Model;

namespace KRS.DataAccess.DataContext
{
    public class KRSContext : DbContext
    {
        static KRSContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<KitchenContext, Configuration>());
        }
        public KRSContext() : base("Name=DataAccess.Context.KitchenContext") { }
        private DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
