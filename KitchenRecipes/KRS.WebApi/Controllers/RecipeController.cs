using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.WebApi.Controllers
{
    public class GroupS
    {
        public int Count { get; set; }
        public string Ingredient { get; set; }
    }
    public class RecipeController : ApiBaseController
    {
        public RecipeController(IKRSUow uow)
        {
            Uow = uow;
        }

        #region OData Future: IQueryable<T>
        //[Queryable]
        // public IQueryable<Session> Get()
        #endregion

        public IEnumerable<Recipe> Get()
        {
            return Uow.Recipes.GetAll()
              .OrderBy(r => r.Name);
        } 

        // GET /api/sessions
        public IEnumerable<GroupS> Get(string name)
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

        public IEnumerable<Ingredient> GetIngredients(string recipeName)
        {
            return Uow.Recipes.GetRecipeIngredients(recipeName);
        }

        public IEnumerable<string> GetRecipesByIngredientName(string ingredientName)
        {
            return Uow.Recipes.GetRecipesThatIncludeIngredient(ingredientName).Select(r => r.Name);
        }

        // GET /api/sessions/5
        public Recipe Get(int id)
        {

            var session = Uow.Recipes.GetById(id);
            if (session != null) return session;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Session
        // POST /api/session
        public HttpResponseMessage Post(Recipe session)
        {
            Uow.Recipes.Add(session);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, session);

            // Compose location header that tells how to get this session
            // e.g. ~/api/session/5
            response.Headers.Location =
                new Uri(Url.Link("ControllerAndId", new { id = session.Id }));

            return response;
        }

        // Update an existing Session
        // PUT /api/sessions/
        public HttpResponseMessage Put(Recipe session)
        {
            Uow.Recipes.Update(session);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/sessions/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Recipes.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
