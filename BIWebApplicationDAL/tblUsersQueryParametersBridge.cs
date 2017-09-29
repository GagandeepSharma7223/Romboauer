
namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class tblUsersQueryParametersBridge
    {
        public long ParameterID { get; set; }
        public long QueryID { get; set; }
    }
}
