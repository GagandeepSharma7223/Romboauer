using BIWebApplicationDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BIWebApplicationBLL.Repository
{
    public class Cls_User_Profile
    {
        public static int GetUserID(string userName)
        {

            int strReturn = 0;
            try
            {
                using (var db = new BIWebModel())
                {
                    var query = db.tblUsers.Where(x => x.ASPNetUsersID == userName);
                    strReturn = Convert.ToInt32(query.Select(x => x.UserID).FirstOrDefault());
                }
            }
            catch (SQLiteException ex)
            {
                //  MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues SQLite Error");
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            finally
            {

            }

            return strReturn;
        }


        public static int IsUserAdminID(long userID)
        {
            int strReturn = 0;
            try
            {
                using (var db = new BIWebModel())
                {
                    var query = db.tblUsers.Where(x => x.UserID == userID);
                    strReturn = Convert.ToInt32(query.Select(x => x.blnUserAdmin).FirstOrDefault());

                }
            }
            catch (SQLiteException ex)
            {
                //  MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues SQLite Error");
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            finally
            {

            }

            return strReturn;



        }

        private static List<Cls_Menu> LoadMenuDataTable(long strUserID)
        {
            List<Cls_Menu> obj_dataTable = new List<Cls_Menu>();
            try
            {
                using (var db = new BIWebModel())
                {
                    var result = from a in db.tblUsers
                                 join h in db.tblGroupMenus on a.GroupID equals h.GroupID
                                 join c in db.tblQueryMains on h.MenuID equals c.MenuID
                                 join cg in db.tblQueryMains on c.ConnectionID equals cg.ConnectionID
                                 where a.UserID == strUserID
                                 select new Cls_Menu
                                 {
                               // MenuID =  h.MenuID,
                                 MenuName =    h.MenuText,
                                 QueryID=    c.QueryID
                                 };
                   
                    obj_dataTable = result.ToList();

                  
                }
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            return obj_dataTable;


        }

        public static List<Cls_Menu> GetMenus()
        {
            object pending_subscribers_dataset = new DataSet();
            int userId = Convert.ToInt32( HttpContext.Current.Session["UserID"]);
            List<Cls_Menu> lstMenu = new List<Cls_Menu>();
            if ((userId > 0))
            {
                DataTable obj_dataTable = new DataTable() ;
                lstMenu = LoadMenuDataTable(userId);
                
            }
            return lstMenu;
        }
    }
}
