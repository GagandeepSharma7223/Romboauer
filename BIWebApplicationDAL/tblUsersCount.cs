
namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   public partial class tblUsersCount
    {
        [Key]
        public long UserID { get; set; }

        public long ReportCount { get; set; }

        public long intWeek { get; set; }

        public long intMonth { get; set; }

        public long intYear { get; set; }
    }
}
