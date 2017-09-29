
namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUsersQueryParameters
    {
        public long UserID { get; set; }

        public long ParameterID { get; set; }

        
        public string ParameterValue { get; set; }
    }
}
