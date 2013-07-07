using System.Linq;
using System.Security.Principal;
using KRS.Web.Core.Models;

namespace KRS.Web.Core.Extensions
{
    public static class SecurityExtensions
    {
      public static string Name(this IPrincipal user)
        {
            return user.Identity.Name;
        }

        public static bool InAnyRole(this IPrincipal user, params string[] roles)
        {
            return roles.Any(user.IsInRole);
        }

        public static KRSUser GetKRSUser(this IPrincipal principal)
        {
            if (principal.Identity is KRSUser)
                return (KRSUser)principal.Identity;
            return new KRSUser(string.Empty, new UserInfo());
        }
    }    
}
