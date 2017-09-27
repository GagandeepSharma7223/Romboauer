using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Models
{
    public class UserModel
    {
        public long UserID { get; set; }
        public string ASPNetUsersID { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Group is required")]
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
