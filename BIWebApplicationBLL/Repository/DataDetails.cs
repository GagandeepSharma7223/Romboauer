using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Repository
{
  public class DataDetails
    {

        public static DataTable GetData(string query, string strConnection, DataTable datParameters)
        {

            EncryptString objEncrypt = new EncryptString("4L8SAb36HK3v8nA6SHA");

            using ( var connection = new SqlConnection())
            {
                connection.ConnectionString = objEncrypt.DecryptData(strConnection); //"Data Source=DESKTOP-UV748D4\\MSSQLSERVER2014;Initial Catalog=Romboauer;Integrated Security=SSPI;"; //

                AddCommandParameters(datParameters, ref query);
                using (var command = new SqlCommand(query, connection))
                {

                    DataTable dt = new DataTable();
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        dt.Load(reader);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        command.Dispose();
                    }

                    return dt;
                }
            }
        }

        private static void AddCommandParameters(DataTable datParameters, ref string strQuery)
        {
            try
            {
                SqlParameter param = default(SqlParameter);
                string strType = null;
                int intIndex = 0;

                foreach (DataRow objRow in datParameters.Rows)
                {
                    strQuery = strQuery.Replace(objRow[0].ToString(), PrepareStr(objRow[2].ToString(), false));
                }
            }
            catch (Exception ex)
            {
               // Interaction.MsgBox(ex.Message);
            }


        }

        private static string PrepareStr(string strValue, bool blnNoQuotes = false)
        {

            if ((strValue == null))
            {
                return "NULL";
            }
            else
            {
                if ((string.IsNullOrEmpty(strValue.Trim())))
                {
                    return "NULL";
                }
                else
                {
                    if (blnNoQuotes == false)
                    {
                        return "'" + strValue.Trim() + "'";
                    }
                    else
                    {
                        return strValue.Trim();
                    }
                }
            }

        }

        public static List<string> GetDataDetail(string query, int intCount, string strConnection)
        {

            List<string> strValues = new List<string>();
            EncryptString objEncrypt = new EncryptString("4L8SAb36HK3v8nA6SHA");

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = objEncrypt.DecryptData(strConnection);
                connection.Open();
                try
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            for (int intvalue = 0; intvalue <= intCount - 1; intvalue++)
                            {
                                strValues.Add(reader.GetString(intvalue));
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return strValues;
            }


        }

        public static DataTable GetUserListDetail(string query, int intCount)
        {

            using (var connection = new SQLiteConnection())
            {
                connection.ConnectionString = Cls_Website.GetUserConnectionString();
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                
                    DataTable dt = new DataTable();
                    try
                    {
                        SQLiteDataReader reader = command.ExecuteReader();
                        dt.Load(reader);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        command.Dispose();
                    }

                    return dt;
                }


            }


        }

    }
}
