using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Repository
{
   public class Cls_Website
    {
        public static string GetConnectionString()
        {
            string str_connection_string = "";
            str_connection_string = ConfigurationManager.ConnectionStrings["RIConnectionString"].ConnectionString;
            return str_connection_string;
        }

        public static string GetUserConnectionString()
        {
            string str_connection_string = "";
            str_connection_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return str_connection_string;
        }
    }
}
