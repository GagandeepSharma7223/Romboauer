using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repo;
        private IMainGridRepository repoGrid;


        public HomeController()
        {
            repo = new UserRepository();
            repoGrid = new MainGridRepository();
        }
        public ActionResult Index()
       {

            long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);

            

            return View(new CategoriesData());

            
        }
        public ActionResult DataGridMain()
        {
            long queryId = 1;
            long userId = 1;

            var queryInfo = repoGrid.LoadQueryInfo(queryId);
            var dataParameters = repoGrid.LoadUserParameters(queryId, userId);
            var datacol = repoGrid.CreateColumns(queryId);
            var dataFormatValue = repoGrid.CreateColumnDataFormatValues(queryId);
            
            DataTable dtpar = ToDataTable(dataParameters);
            var grd = DataDetails.GetData(queryInfo[0].strQuery.ToString(), queryInfo[0].strConnection.ToString(),dtpar);

            return View();
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {  
            ViewBag.Message = "Your contact page.";
            return View();
        }

        
    }
}