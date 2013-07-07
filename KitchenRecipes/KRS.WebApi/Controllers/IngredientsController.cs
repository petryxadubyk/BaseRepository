using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.Model.RecipesParts;

namespace KRS.WebApi.Controllers
{
    public class IngredientsController : ApiBaseController
    {
        public IngredientsController(IKRSUow uow)
        {
            Uow = uow;
        }
        // GET api/ingredients
        public IEnumerable<Ingredient> Get()
        {
            return Uow.Ingredients.GetAll()
             .OrderBy(r => r.Name);
        }

        // GET api/ingredients/5
        public Ingredient Get(int id)
        {
            return Uow.Ingredients.GetById(id);
        }
        // Create a new Session
        // POST /api/recipes
        public HttpResponseMessage Post(Ingredient ingredient)
        {
            Uow.Ingredients.Add(ingredient);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, ingredient);

            // Compose location header that tells how to get this session
            // e.g. ~/api/session/5
            response.Headers.Location =
                new Uri(Url.Link(RouteConfig.ControllerAndId, new { id = ingredient.Id }));

            return response;
        }

        // Update an existing Session
        // PUT /api/recipes/
        public HttpResponseMessage Put(Ingredient ingredient)
        {
            Uow.Ingredients.Update(ingredient);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/recipes/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Ingredients.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
