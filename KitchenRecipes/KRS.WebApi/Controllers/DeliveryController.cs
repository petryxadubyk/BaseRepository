using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Repositories;
using KRS.Model;

namespace KRS.WebApi.Controllers
{
    public class DeliveryController : ApiController
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryController(IDeliveryRepository deliveryRepository)
        {
            this._deliveryRepository = deliveryRepository;
        }
        public IQueryable<Delivery> Get()
        {
            var deliveries = _deliveryRepository.GetDeliveries().AsQueryable();
            return deliveries;
        }

        // GET api/Default1/5
        public Delivery GetDelivery(int id)
        {
            Delivery delivery = _deliveryRepository.GetById(id);
            if (delivery == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return delivery;
        }

        /* private readonly DeliveryManager _deliveryManager = new DeliveryManager();

         // GET api/Default1
         public List<Delivery> GetDeliveries()
         {
             return _deliveryManager.GetDeliveries();
         }

         // GET api/Default1/5
         public Delivery GetDelivery(int id)
         {
             Delivery delivery = _deliveryManager.GetDelivery(id);
             if (delivery == null)
             {
                 throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
             }

             return delivery;
         }

         // PUT api/Default1/5
         public HttpResponseMessage PutDelivery(int id, Delivery delivery)
         {
             if (ModelState.IsValid && id == delivery.DeliveryId)
             {
                 if (_deliveryManager.PostDelivery(delivery))
                     return Request.CreateResponse(HttpStatusCode.OK);
                 return Request.CreateResponse(HttpStatusCode.NotFound);
             }
             return Request.CreateResponse(HttpStatusCode.BadRequest);
         }

         // POST api/Default1
         public HttpResponseMessage PostDelivery(Delivery delivery)
         {
             if (ModelState.IsValid)
             {
                 if (_deliveryManager.PostDelivery(delivery))
                 {
                     HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, delivery);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = delivery.DeliveryId}));
                     return response;
                 }
                 return Request.CreateResponse(HttpStatusCode.BadRequest);
             }
             return Request.CreateResponse(HttpStatusCode.BadRequest);
         }

         // DELETE api/Default1/5
         public HttpResponseMessage DeleteDelivery(int id)
         {
             Delivery delivery = _deliveryManager.DeleteDelivery(id);
             if (delivery == null)
             {
                 return Request.CreateResponse(HttpStatusCode.NotFound);
             }

             return Request.CreateResponse(HttpStatusCode.OK, delivery);
         }*/
    }
}