using BIWebApplication.Models;
using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using BIWebApplicationDAL;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIWebApplication.Controllers
{
    public class AdminController : Controller
    {

        private IUserRepository repo;

        public AdminController()
        {
            repo = new UserRepository();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminUsers()
        {
            List<UserModel> lstUsers = new List<UserModel>();
            ViewBag.GroupDetail = repo.GetGroups();
            lstUsers = repo.GetUsers();
            var res = repo.GetUsers();
            return View(lstUsers);
        }

        [ValidateInput(false)]
        public ActionResult EditModesPartial()
        {
            ViewBag.GroupDetail = repo.GetGroups();
            return PartialView("_EditAdminUsers", repo.GetUsers());
        }

        //public ActionResult ChangeEditModePartial(GridViewEditingMode editMode)
        //{
        //    GridViewEditingDemosHelper.EditMode = editMode;
        //    return PartialView("EditModesPartial", repo.GetUsers());
        //}
        public ActionResult AddUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.AddUser(user);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_EditAdminUsers", repo.GetUsers());
        }
    }
}