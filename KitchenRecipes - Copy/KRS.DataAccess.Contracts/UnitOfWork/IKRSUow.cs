using KRS.DataAccess.Contracts.Repositories;
using KRS.DataAccess.Contracts.Repositories.Core;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.Photos;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.Contracts.UnitOfWork
{
    /// <summary>
    /// Interface for the Kitchen Recipes "Unit of Work"
    /// </summary>
    public interface IKRSUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRecipeRepository Recipes { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<CookProcess> CookProcesses { get; }
        IRepository<Kitchenware> Kitchenwares { get; }

        IRepository<Photo> Photos { get; }

        IRepository<RecipesCookProcesses> RecipesCookProcesses { get; }
        IRepository<RecipesKitchenwares> RecipesKitchenwares { get; }
        IRepository<RecipesIngredients> RecipesIngredients { get; }

        IRepository<IngredientCategory> IngredientCategory { get; }
        IRepository<RecipeCategory> RecipeCategory { get; }
        IRepository<KitchenwareCategory> KitchenwareCategory { get; }
    }
}
