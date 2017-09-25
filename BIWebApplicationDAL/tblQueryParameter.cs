namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblQueryParameter
    {
        [Key]
        public long ParameterID { get; set; }

        public long? GroupID { get; set; }

        [StringLength(2147483647)]
        public string ParameterType { get; set; }

        [StringLength(2147483647)]
        public string ParameterName { get; set; }

        [StringLength(2147483647)]
        public string ParameterLabel { get; set; }
    }
}
