using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.Model.RecipesParts;

namespace KRS.WebApi.Controllers
{
    public class KitchenwaresController : ApiBaseController
    {
        public KitchenwaresController(IKRSUow uow)
        {
            Uow = uow;
        }
        // GET api/ingredients
        public IEnumerable<Kitchenware> Get()
        {
            return Uow.Kitchenwares.GetAll()
             .OrderBy(r => r.Name);
        }

        // GET api/ingredients/5
        public Kitchenware Get(int id)
        {
            return Uow.Kitchenwares.GetById(id);
        }
        // Create a new Session
        // POST /api/recipes
        public HttpResponseMessage Post(Kitchenware kitchenware)
        {
            Uow.Kitchenwares.Add(kitchenware);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, kitchenware);

            // Compose location header that tells how to get this session
            // e.g. ~/api/session/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = kitchenware.Id }));

            return response;
        }

        // Update an existing Session
        // PUT /api/recipes/
        public HttpResponseMessage Put(Kitchenware kitchenware)
        {
            Uow.Kitchenwares.Update(kitchenware);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/recipes/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Kitchenwares.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
