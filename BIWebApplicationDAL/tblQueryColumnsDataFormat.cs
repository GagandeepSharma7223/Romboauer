namespace BIWebApplicationDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblQueryColumnsDataFormat
    {
        public long ColumnID { get; set; }
        public string ColumnDataFormula { get; set; }
        public string ColumnDataFormatBackColor { get; set; }
        public string ColumnDataFormatForeColor { get; set; }
    }
}
