using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.DataAccess.Contracts.Repositories.Core;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;
using KRS.Model.ViewModels;

namespace KRS.DataAccess.Contracts.Repositories
{
    public interface IRecipeRepository: IRepository<Recipe>
    {
        IEnumerable<Ingredient> GetRecipeIngredients(string recipeName);
        IEnumerable<Recipe> GetRecipesThatIncludeIngredient(string ingredientName);
        IEnumerable<Recipe> GetByUserId(int id);
        IEnumerable<RecipeBrief> GetBriefRecipes();
    }
}
