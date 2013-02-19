using System;
using System.Data.Entity;
using System.Linq;
using KRS.DataAccess.Contracts.Repositories;
using KRS.DataAccess.Repositories.Core;
using KRS.Model.Recipes;

namespace KRS.DataAccess.Repositories
{
    public class RecipeRepository : BaseEntityRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context) { }

        public IQueryable<Recipe> GetByIngredientId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Recipe> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }


    }
}
