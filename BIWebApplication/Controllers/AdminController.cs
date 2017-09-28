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
        private ApplicationSignInManager _signInManager;
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
            return View(lstUsers);
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        [ValidateInput(false)]
        public ActionResult EditModesPartial()
        {
            ViewBag.GroupDetail = repo.GetGroups();
            return PartialView("_EditAdminUsers", repo.GetUsers());
        }

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
            if (ModelState.IsValid)
            {
                try
                {
                    string email = user.Email.Replace('"', ' ').Trim();
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(user.ChangePassword) && !string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.UserFullName) )
                    {
                        string name = user.UserName.Replace('"', ' ').Trim();
                     

                        var usernew = new ApplicationUser { UserName = name, Email = email };
                        var result = UserManager.Create(usernew, user.ChangePassword);
                        if (result.Succeeded)
                        {
                            await SignInManager.SignInAsync(usernew, isPersistent: false, rememberBrowser: false);
                            user.ASPNetUsersID = usernew.Id;
                            string fullname = user.UserFullName.Replace('"', ' ').Trim();

                            user.UserFullName = fullname;

                            repo.AddUser(user);
                        }

                    }
                    else {
                        ViewData["EditError"] = "Please, correct all errors.";
                    }
                       
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            ViewBag.GroupDetail = repo.GetGroups();
          
            return PartialView("_EditAdminUsers", repo.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserModel user)
        {

            user.UserID = repo.GetUserId(user.ASPNetUsersID);
            
                try
                {
                    string name = user.UserName.Replace('"', ' ').Trim();
                    string email = user.Email.Replace('"', ' ').Trim();
                string phone = ""  ;
                if(!string.IsNullOrEmpty(user.PhoneNumber))
                {
                    phone = user.PhoneNumber.Replace('"', ' ').Trim();
                }
                if (!string.IsNullOrEmpty(user.ChangePassword))
                {
                    var userStore = new UserStore<IdentityUser>();
                    var manager = new UserManager<IdentityUser>(userStore);
                    IdentityUser cUser = manager.FindById(user.ASPNetUsersID);
                    cUser.PasswordHash = manager.PasswordHasher.HashPassword(user.ChangePassword);
                    var result = manager.UpdateAsync(cUser).Result;
                }
                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.UserFullName))
                {
                    string fullname = user.UserFullName.Replace('"', ' ').Trim();

                    user.UserFullName = fullname;
                    user.Email  = email;
                    user.PhoneNumber = phone;
                    user.UserName = name;
                    repo.UpdateUser(user);

                }


            }
            catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
           
            
            ViewBag.GroupDetail = repo.GetGroups();

            return PartialView("_EditAdminUsers", repo.GetUsers());
        }
    }
}