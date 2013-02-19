using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;
using KRS.Model.Recipes;

namespace KRS.WebApi.Controllers
{
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

        // GET /api/sessions
        public IEnumerable<Recipe> Get()
        {
            return Uow.Recipes.GetAll()
                .OrderBy(r => r.Name);
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
