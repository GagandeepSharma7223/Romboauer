namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQueryMain")]
    public partial class tblQueryMain
    {
        [Key]
        public long QueryID { get; set; }

        public long? MenuID { get; set; }

        public long? ConnectionID { get; set; }

        [StringLength(2147483647)]
        public string QueryFrom { get; set; }

        [StringLength(2147483647)]
        public string QueryWhereAdd { get; set; }

        public long? QueryOrder { get; set; }

        public long? QueryType { get; set; }

        public long? blnRunFilterFirst { get; set; }

        public long? DetailQueryID { get; set; }
    }
}
