using BIWebApplication.Models;
using BIWebApplicationDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIWebApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminUsers()
        {
             List<AdminUserModel> lstUsers = new List<AdminUserModel>();
            using (var db = new BIWebModel())
            {
                var result = from a in db.tblGroups                             
                             select new 
                             {
                                  a.GroupID,
                                  a.GroupName
                                
                             };

                ViewBag.GroupDetail = result.ToList();

               

                var resultUsers = from a in db.tblUsers
                                  join g in db.tblGroups on a.GroupID equals g.GroupID
                                  join c in db.AspNetUsers on a.ASPNetUsersID equals c.Id
                                  select new AdminUserModel
                                  {
                                  UserID=    a.UserID,
                                      ASPNetUsersID =     a.ASPNetUsersID,
                                      UserName=  c.UserName,
                                      UserFullName=  a.UserFullName,
                                      GroupID=   g.GroupID,
                                      GroupName=     g.GroupName,
                                      Email=  c.Email,
                                      PhoneNumber=  c.PhoneNumber,
                                      blnInactive= a.blnInactive,
                                      blnUserAdmin= a.blnUserAdmin
                                  };

                lstUsers = resultUsers.ToList();
            }
            
            return View(lstUsers);
        }
    }
}