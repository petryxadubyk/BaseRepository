using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KRS.DataAccess.Configurations;
using KRS.DataAccess.SampleData;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.Photos;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;
using KRS.Model.Users;

namespace KRS.DataAccess.DataContext
{
    public class KRSContext : DbContext
    {
        public KRSContext() : 
            base("Name=DataAccess.Context.KitchenContext")
        { 
        }

        static KRSContext()
        {
            Database.SetInitializer(new KRSDatabaseInitializer());
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ExtRecipe> ExtRecipes { get; set; }
        public DbSet<KRSUser> KRSUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public DbSet<KitchenwareCategory> KitchenwareCategories { get; set; }
        public DbSet<CategoryGroup> CategoryTypes { get; set; }

        public DbSet<RecipesIngredients> RecipesIngredients { get; set; }
        public DbSet<RecipesKitchenwares> RecipesKitchenwares { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CookProcess> CookProcesses { get; set; }
        public DbSet<Kitchenware> Kitchenwares { get; set; }

        public DbSet<RecipeSchema> RecipeSchema { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Here we have two collections: Conventions and Configurations

            //Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new RecipeConfiguration());
        }
    }
}
