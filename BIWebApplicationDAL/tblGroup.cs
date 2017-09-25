namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblGroup
    {
        [Key]
        public long GroupID { get; set; }

        public long? CompanyID { get; set; }

        [StringLength(2147483647)]
        public string GroupName { get; set; }
    }
}
