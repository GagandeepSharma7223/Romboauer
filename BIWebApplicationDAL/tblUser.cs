namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUser
    {
        [Key]
        public long UserID { get; set; }

        public long? CompanyID { get; set; }

        [StringLength(2147483647)]
        public string ASPNetUsersID { get; set; }

        public long? GroupID { get; set; }

        [StringLength(2147483647)]
        public string UserFullName { get; set; }

        [StringLength(2147483647)]
        public string UserField1 { get; set; }

        [StringLength(2147483647)]
        public string UserField2 { get; set; }

        [StringLength(2147483647)]
        public string UserField3 { get; set; }

        [StringLength(2147483647)]
        public string UserField4 { get; set; }

        public long? blnInactive { get; set; }

        public long? blnUserAdmin { get; set; }

        public long? blnChangePassword { get; set; }
    }
}
