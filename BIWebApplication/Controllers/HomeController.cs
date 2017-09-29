using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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


            return View();
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