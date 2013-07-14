using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KRS.DataAccess.Contracts.Repositories;
using KRS.DataAccess.Repositories.Core;
using KRS.Model.Infrastructure;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;
using KRS.Model.ViewModels;

namespace KRS.DataAccess.Repositories
{
    public class RecipeRepository : BaseEntityRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context) { }

        public IEnumerable<Ingredient> GetRecipeIngredients(int recipeId)
        {
            //інгредієнти які використовуються в рецепті з імям 'name'
            var query = from recipe in DbSet
                        join schema in DbContext.Set<RecipesIngredients>() on recipe.Id equals schema.Recipe.Id
                        join ingredient in DbContext.Set<Ingredient>() on schema.Ingredient.Id equals ingredient.Id
                        where recipe.Id == recipeId
                        select ingredient;

            return query.ToList();
        }

        public IEnumerable<Recipe> GetRecipesThatIncludeIngredient(int ingredientId)
        {
            //рецепти які включають інгредієнт з імям 'name'
            var query2 =
                from ingredient in DbContext.Set<Ingredient>()
                where ingredient.Id == ingredientId
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

        public IEnumerable<RecipeBrief> GetBriefRecipes()
        {
            return DbSet.Select(recipe => new RecipeBrief
                                              {
                                                  Id = recipe.Id,
                                                  Name = recipe.Name,
                                                  Likes = recipe.Likes,
                                                  Dislikes = recipe.Dislikes,
                                                  PhotoPath = recipe.PhotoPath,
                                                  ShortDescription = recipe.ShortDescription
                                              }).ToList();
        }
    }
}
