namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblQueryColumn
    {
        [Key]
        public long ColumnID { get; set; }

        public long? QueryID { get; set; }

        [StringLength(2147483647)]
        public string ColumnName { get; set; }

        [StringLength(2147483647)]
        public string ColumnHeader { get; set; }

        public long? ColumnOrder { get; set; }

        public long? ColumnDataType { get; set; }

        public long? ColumnWidth { get; set; }

        [StringLength(2147483647)]
        public string ColumnFormat { get; set; }

        public long? DetailColumn { get; set; }
    }
}
