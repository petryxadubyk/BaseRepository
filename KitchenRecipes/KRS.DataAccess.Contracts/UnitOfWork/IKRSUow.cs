using KRS.DataAccess.Contracts.Repositories;
using KRS.DataAccess.Contracts.Repositories.Core;
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
    }
}
