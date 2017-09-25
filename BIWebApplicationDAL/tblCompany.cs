namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCompany")]
    public partial class tblCompany
    {
        [Key]
        public long CompanyID { get; set; }

        [StringLength(2147483647)]
        public string CompanyName { get; set; }

        [StringLength(2147483647)]
        public string CompanyLogo { get; set; }
    }
}
