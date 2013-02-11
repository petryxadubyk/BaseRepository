using System;
using System.Collections.Generic;
using System.Linq;
using KRS.DataAccess.IInfrastructure;
using KRS.DataAccess.IRepositories;
using KRS.Model.Categories;
using KRS.Model.Recipes;

namespace KRS.DataAccess.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            var recipes = DataContext.Recipes.OrderBy(r => r.Name);
            return recipes.ToList();
        }

        public IEnumerable<Recipe> CreateRecipe(String name)
        {
            var recipe = new Recipe
                           {
                              
                               Name = name,
                               Likes = 1,
                               Dislikes = 0,
                               ModifiedOn = DateTime.Now,
                               
                               Category = new RecipeCategory {Name = "Category 1"},
                           };
            
            DataContext.Recipes.Add(recipe);
            DataContext.SaveChanges();

            var recipes = DataContext.Recipes.OrderBy(r => r.Name);
            return recipes.ToList();
        }
    }

    public interface IRecipeRepository : IRepository<Recipe>
    {
        IEnumerable<Recipe> GetRecipes();
        IEnumerable<Recipe> CreateRecipe(String name);
    }
}
