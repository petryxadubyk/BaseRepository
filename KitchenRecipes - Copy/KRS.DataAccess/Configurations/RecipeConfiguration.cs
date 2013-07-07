using System.Data.Entity.ModelConfiguration;
using KRS.Model.Recipes;

namespace KRS.DataAccess.Configurations
{
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            //many to many
            HasMany(recipe => recipe.Users)
                .WithMany(user => user.Recipes)
                .Map(t => t.MapLeftKey("Id")
                    .MapRightKey("Id")
                    .ToTable("Recipes_Users"));

            HasMany(recipe => recipe.Categories)
                .WithMany(category => category.Recipes)
                .Map(t => t.MapLeftKey("Id")
                    .MapRightKey("Id")
                    .ToTable("Recipes_Categories"));

            //one to many
            HasMany(recipe => recipe.Photos)
                .WithOptional()
                .WillCascadeOnDelete(true);

            HasMany(recipe => recipe.IngredientsRelation)
                .WithRequired(schema => schema.Recipe)
                .WillCascadeOnDelete(true);

            HasMany(recipe => recipe.KitchenwaresRelation)
                .WithRequired(schema => schema.Recipe)
                .WillCascadeOnDelete(true);

            HasMany(recipe => recipe.CookProcessesRelation)
                .WithRequired(schema => schema.Recipe)
                .WillCascadeOnDelete(true);

            //one to one or zero
            HasOptional(recipe => recipe.ExtRecipe);
        }

    }
}
