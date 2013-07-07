using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Contracts.UnitOfWork;

namespace KRS.WebApi.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected IKRSUow Uow { get; set; }
    }
}
