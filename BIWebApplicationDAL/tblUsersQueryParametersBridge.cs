
namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQueryParametersBridge")]
    public partial class tblQueryParametersBridge
    {
        [Key]
        public long ParameterID { get; set; }
        public long QueryID { get; set; }
    }
}
