using System;
using System.Web.Mvc;

namespace KRS.Web.Core.ActionFilters
{
    public class KRSAuthorize : AuthorizeAttribute
    {
        public KRSAuthorize(params string[] roles)
        {
            Roles = String.Join(", ", roles);
        }
    }
}
