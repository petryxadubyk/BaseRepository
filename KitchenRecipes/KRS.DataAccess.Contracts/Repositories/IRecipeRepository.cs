using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.DataAccess.Contracts.Repositories.Core;
using KRS.Model.Recipes;

namespace KRS.DataAccess.Contracts.Repositories
{
    public interface IRecipeRepository: IRepository<Recipe>
    {
        IQueryable<Recipe> GetByIngredientId(int id);
        IQueryable<Recipe> GetByUserId(int id);
    }
}
