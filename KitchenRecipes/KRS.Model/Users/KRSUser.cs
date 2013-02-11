using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Core.Common;
using KRS.Model.IUsers;
using KRS.Model.KRS;
using KRS.Model.Recipes;

namespace KRS.Model.Users
{
    public class KRSUser : KRSEntity, IKRSUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public DateTime? LastLoginTime { get; set; }
        public bool Activated { get; set; }
        public int RoleId { get; set; }

        public string Password
        {
            set { PasswordHash = Md5Encrypt.Md5EncryptPassword(value); }
        }
        internal static string GenerateRandomString()
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble() + 75)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public string ResetPassword()
        {
            var newPass = GenerateRandomString();
            Password = newPass;
            return newPass;
        }
        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }

        //relations
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
