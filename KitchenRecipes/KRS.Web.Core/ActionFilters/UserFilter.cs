using System.Web.Mvc;
using KRS.Web.Core.Extensions;
using KRS.Web.Core.Models;

namespace KRS.Web.Core.ActionFilters
{

    //Inject a ViewBag object to Views for getting information about an authenticated user
    public class UserFilter : ActionFilterAttribute
    {
        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserModel userModel;
            if (filterContext.Controller.ViewBag.UserModel == null)
            {
                userModel = new UserModel();
                filterContext.Controller.ViewBag.UserModel = userModel;
            }
            else
            {
                userModel = filterContext.Controller.ViewBag.UserModel as UserModel;
            }
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                KRSUser efmvcUser = filterContext.HttpContext.User.GetKRSUser();
                userModel.IsUserAuthenticated = efmvcUser.IsAuthenticated;
                userModel.UserName = efmvcUser.DisplayName;
                userModel.RoleName = efmvcUser.RoleName;
            }

            base.OnActionExecuted(filterContext);
        }
    }
    public class UserModel
    {
        public bool IsUserAuthenticated  { get; set;}
        public string UserName { get; set; }
        public string RoleName { get; set; }        
    }
}
