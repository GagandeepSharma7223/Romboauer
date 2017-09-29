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

    public class MainGrid
    {
        public string strConnection { get; set; }
        public string strQuery { get; set; }
       
       
    }

    public class CreateColumnDataFormatValue
    {
        public string ColumnName { get; set; }
        public string ColumnDataFormula { get; set; }
        public string ColumnDataFormatForeColor { get; set; }       
        public string ColumnDataFormatBackColor { get; set; }
    }
    public class CreateColumn
    {
        public string ColumnName { get; set; }
        public string ColumnHeader { get; set; }
        public long? ColumnWidth { get; set; }
        public long? DetailColumn { get; set; }
        public string ColumnFormat { get; set; }
    }
    public class QueryUserVariables
    {
        public string ConnectionValue { get; set; }
        public string QueryFrom { get; set; }

        public long? DetailQueryID { get; set; }


    }

    public class UserParameters
    {
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }

        public string ParameterValue { get; set; }


    }
}
