using System.Web;
using System.Web.Mvc;
using KRS.Web.Core.ActionFilters;

namespace KRS.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new DisableCache());
        }
    }
}