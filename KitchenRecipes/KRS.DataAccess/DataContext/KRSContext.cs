using System.Data.Entity;
using KRS.Model;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.Photos;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts.CookProcesses;
using KRS.Model.RecipesParts.Ingredients;
using KRS.Model.RecipesParts.Kitchenware;
using KRS.Model.Users;

namespace KRS.DataAccess.DataContext
{
    public class KRSContext : DbContext
    {
        public KRSContext() : 
            base("Name=DataAccess.Context.KitchenContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<KRSContext, Configuration>());
        }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<KRSUser> KRSUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<NationalCategory> NationalCategories { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public DbSet<KitchenwareCategory> KitchenwareCategories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CookProcess> CookProcesses { get; set; }
        public DbSet<Kitchenware> Kitchenwares { get; set; }

        public DbSet<RecipeSchema> RecipeSchema { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Recipe>().Property(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
