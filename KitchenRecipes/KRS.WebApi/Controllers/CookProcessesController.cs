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
    public class CookProcessesController : ApiBaseController
    {
        public CookProcessesController(IKRSUow uow)
        {
            Uow = uow;
        }
        // GET api/ingredients
        public IEnumerable<CookProcess> Get()
        {
            return Uow.CookProcesses.GetAll()
             .OrderBy(r => r.Name);
        }

        // GET api/ingredients/5
        public CookProcess Get(int id)
        {
            return Uow.CookProcesses.GetById(id);
        }
        // Create a new Session
        // POST /api/recipes
        public HttpResponseMessage Post(CookProcess cookProcess)
        {
            Uow.CookProcesses.Add(cookProcess);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, cookProcess);

            // Compose location header that tells how to get this session
            // e.g. ~/api/session/5
            response.Headers.Location =
                new Uri(Url.Link(RouteConfig.ControllerAndId, new { id = cookProcess.Id }));

            return response;
        }

        // Update an existing Session
        // PUT /api/recipes/
        public HttpResponseMessage Put(CookProcess cookProcess)
        {
            Uow.CookProcesses.Update(cookProcess);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/recipes/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.CookProcesses.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
