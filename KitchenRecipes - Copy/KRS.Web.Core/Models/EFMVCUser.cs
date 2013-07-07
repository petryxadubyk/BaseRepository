using System;
using System.Web.Security;
using System.Security.Principal;

namespace KRS.Web.Core.Models
{ 
    [Serializable]
    public class KRSUser : IIdentity
    {
        public KRSUser(){}
        public KRSUser(string name, string displayName, int userId)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.UserId = userId;
        }
        public KRSUser(string name, string displayName, int userId,string roleName)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.UserId = userId;
            this.RoleName = roleName;
        }
        public KRSUser(string name, UserInfo userInfo)
            : this(name, userInfo.DisplayName, userInfo.UserId,userInfo.RoleName)
        {
            if (userInfo == null) throw new ArgumentNullException("userInfo");
            this.UserId = userInfo.UserId;
        }

        public KRSUser(FormsAuthenticationTicket ticket)
            : this(ticket.Name, UserInfo.FromString(ticket.UserData))
        {
            if (ticket == null) throw new ArgumentNullException("ticket");
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "KRSForms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string DisplayName { get; private set; }
        public string RoleName { get; private set; }
        public int UserId { get; private set; }
    }
}
