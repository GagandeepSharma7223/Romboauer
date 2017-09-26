using BIWebApplication.Models;
using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using BIWebApplicationDAL;
using DevExpress.Web;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace BIWebApplication.Controllers
{
    public class AdminController : Controller
    {

        private IUserRepository repo;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
            repo = new UserRepository();
        }

        public AdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;            
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
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<ActionResult> AddUser(UserModel user)
        {

            //long userId = (long)System.Web.HttpContext.Current.Session["UserID"]; //HttpContext.Current.Session["UserID"];

            //user.UserID = userId;
            //user.CompanyId = repo.GetCompanyID(userId);

            if (ModelState.IsValid)
            {
                try
                {
                    string name = user.UserName.Replace('"', ' ').Trim();
                    string email = user.Email.Replace('"', ' ').Trim();

                    var usernew = new ApplicationUser { UserName = name, Email = email };
                    var result =  UserManager.Create(usernew, user.ChangePassword);
                    if (result.Succeeded)
                    {
                        user.ASPNetUsersID = usernew.Id;




                        repo.AddUser(user);
                    }


                       
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