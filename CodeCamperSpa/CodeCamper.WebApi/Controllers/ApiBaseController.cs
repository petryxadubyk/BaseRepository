using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeCamper.Data.Contracts;

namespace CodeCamper.WebApi.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected ICodeCamperUow Uow { get; set; }
    }
}
