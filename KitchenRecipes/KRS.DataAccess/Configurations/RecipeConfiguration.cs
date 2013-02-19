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

            HasMany(recipe => recipe.CookProcesses)
                .WithMany(cook => cook.Recipes)
                .Map(t => t.MapLeftKey("Id")
                    .MapRightKey("Id")
                    .ToTable("Recipes_CookProcesses"));

            //one to many
            HasMany(recipe => recipe.Photos)
                .WithOptional()
                .WillCascadeOnDelete(true);

            HasMany(recipe => recipe.RecipeSchemas)
                .WithRequired(schema => schema.Recipe)
                .WillCascadeOnDelete(true);

            //one to one or zero
            HasOptional(recipe => recipe.ExtRecipe);
        }

    }
}
