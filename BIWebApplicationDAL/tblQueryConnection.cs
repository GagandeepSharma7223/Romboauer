namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblQueryConnection
    {
        [Key]
        public long ConnectionID { get; set; }

        [StringLength(2147483647)]
        public string ConnectionName { get; set; }

        [StringLength(2147483647)]
        public string ConnectionValue { get; set; }
    }
}
