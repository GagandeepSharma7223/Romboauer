namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGroupMenu")]
    public partial class tblGroupMenu
    {
        [Key]
        public long MenuID { get; set; }

        public long? GroupID { get; set; }

        [StringLength(2147483647)]
        public string MenuText { get; set; }

        public long? MenuOrder { get; set; }
    }
}
