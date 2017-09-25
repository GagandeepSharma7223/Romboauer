namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQueryDetail")]
    public partial class tblQueryDetail
    {
        [Key]
        public long DetailQueryID { get; set; }

        [StringLength(2147483647)]
        public string ParameterName { get; set; }

        [StringLength(2147483647)]
        public string ParameterColumnID { get; set; }

        [StringLength(2147483647)]
        public string ParameterValue { get; set; }
    }
}
