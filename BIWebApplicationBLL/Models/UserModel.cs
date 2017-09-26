using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Models
{
    public class UserModel
    {
        public long UserID { get; set; }
        public string ASPNetUsersID { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public long GroupID { get; set; }
        public string GroupName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberFormated { get; set; }
        public long? blnInactive { get; set; }
        public long? blnUserAdmin { get; set; }

        public long? CompanyId { get; set; }
        public string ChangePassword { get; set; }
    }
}
