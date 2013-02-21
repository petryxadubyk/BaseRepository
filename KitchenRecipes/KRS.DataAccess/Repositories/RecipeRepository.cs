using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KRS.DataAccess.Contracts.Repositories;
using KRS.DataAccess.Repositories.Core;
using KRS.Model.Infrastructure;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.Repositories
{
    public class RecipeRepository : BaseEntityRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context) { }

        public IEnumerable<Ingredient> GetRecipeIngredients(string recipeName)
        {
            //інгредієнти які використовуються в рецепті з імям 'name'
            var query = from recipe in DbSet
                        join schema in DbContext.Set<RecipesIngredients>() on recipe.Id equals schema.Recipe.Id
                        join ingredient in DbContext.Set<Ingredient>() on schema.Ingredient.Id equals ingredient.Id
                        where recipe.Name == recipeName
                        select ingredient;

            return query.ToList();
        }

        public IEnumerable<Recipe> GetRecipesThatIncludeIngredient(string ingredientName)
        {
            //рецепти які включають інгредієнт з імям 'name'
            var query2 =
                from ingredient in DbContext.Set<Ingredient>()
                where ingredient.Name == ingredientName
                from recipeIngredients in ingredient.IngredientRecipes
                select recipeIngredients;
            var query3 =
                from recipe in DbSet
                join recipesIngredient in query2 on recipe.Id equals recipesIngredient.Recipe.Id
                select recipe;

            return query3.ToList();
        } 

        public IEnumerable<Recipe> GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

    }
}
