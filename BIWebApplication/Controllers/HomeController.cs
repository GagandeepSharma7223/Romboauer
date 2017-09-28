using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repo;


        public HomeController()
        {
            repo = new UserRepository();
        }
        public ActionResult Index()
       {

            long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);

            //ViewBag.Menu = new CategoriesData(); //repo.LoadMenuDataTable(userId);

            return View(new CategoriesData());

            
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