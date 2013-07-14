using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;
using KRS.Model.ViewModels;

namespace KRS.WebApi.Controllers
{
    public class GroupS
    {
        public int Count { get; set; }
        public string Ingredient { get; set; }
    }
    public class RecipesController : ApiBaseController
    {
        public RecipesController(IKRSUow uow)
        {
            Uow = uow;
        }

        #region OData Future: IQueryable<T>
        //[Queryable]
        // public IQueryable<Session> Get()
        #endregion

        // GET /api/recipes
        [ActionName("all")]
        public IEnumerable<Recipe> Get()
        {
            return Uow.Recipes.GetAll()
              .OrderBy(r => r.Name);
        } 

        // GET /api/recipes/ingredientusage
        [ActionName("ingredientusage")]
        public IEnumerable<GroupS> GetIngredientGroups()
        {
            //групування по інгредієнтах і знаходження кількості рецептів де вони використовуються
            var query4 =
                from recipe in Uow.Recipes.GetAll()
                join schema in Uow.RecipesIngredients.GetAll() on recipe.Id equals schema.Recipe.Id
                join ingredient in Uow.Ingredients.GetAll() on schema.Ingredient.Id equals ingredient.Id
                group ingredient by ingredient.Name
                    into g
                    let count = g.Count()
                    select new GroupS
                               {
                                   Count = count,
                                   Ingredient = g.Key
                               };

            return query4.ToList();
        }

        [ActionName("recipebriefs")]
        public IEnumerable<RecipeBrief> GetRecipeBriefs()
        {
            return Uow.Recipes.GetBriefRecipes();
        }

            // GET /api/recipes/ingredients
        [ActionName("ingredients")]
        public IEnumerable<Ingredient> GetIngredients(int id)
        {
            return Uow.Recipes.GetRecipeIngredients(id);
        }

        // GET /api/recipes/byingredient
        [ActionName("byingredient")]
        public IEnumerable<string> GetRecipesByIngredientName(int id)
        {
            return Uow.Recipes.GetRecipesThatIncludeIngredient(id).Select(r => r.Name);
        }

        // GET /api/recipes/5
        [ActionName("getrecipebyid")]
        public Recipe Get(int id)
        {
            var session = Uow.Recipes.GetById(id);
            if (session != null) return session;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Session
        // POST /api/recipes
        public HttpResponseMessage Post(Recipe recipe)
        {
            Uow.Recipes.Add(recipe);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, recipe);

            // Compose location header that tells how to get this session
            // e.g. ~/api/session/5
            response.Headers.Location =
                new Uri(Url.Link(RouteConfig.ControllerAndId, new { id = recipe.Id }));

            return response;
        }

        // Update an existing Session
        // PUT /api/recipes/
        public HttpResponseMessage Put(Recipe recipe)
        {
            Uow.Recipes.Update(recipe);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/recipes/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Recipes.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
