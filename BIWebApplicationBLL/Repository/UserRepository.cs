using BIWebApplicationBLL.Interface;
using BIWebApplicationBLL.Models;
using BIWebApplicationDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Repository
{
    public class UserRepository : IUserRepository,IDisposable
    {
        //private readonly BIWebModel _context;
        public UserRepository()
        {
          //  _context = new BIWebModel();
        }

        public List<UserModel> GetUsers()
        {
            using (var _context = new BIWebModel())
            {


                return _context.tblUsers
                    .Join(_context.tblGroups, x => x.GroupID, g => g.GroupID, (x, g) => new { x, g })
                    .Join(_context.AspNetUsers, x => x.x.ASPNetUsersID, c => c.Id, (x, c) => new UserModel
                    {
                        UserID = x.x.UserID,
                        ASPNetUsersID = x.x.ASPNetUsersID,
                        UserName = c.UserName,
                        UserFullName = x.x.UserFullName,
                        GroupID = x.g.GroupID,
                        GroupName = x.g.GroupName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        blnInactive = x.x.blnInactive,
                        blnUserAdmin = x.x.blnUserAdmin
                    }).ToList();
            }
        }

        public List<GroupModel> GetGroups()
        {
            using (var _context = new BIWebModel())
            {
                return _context.tblGroups.Select(x => new GroupModel
                {
                    GroupID = x.GroupID,
                    GroupName = x.GroupName
                }).ToList();
            }
        }

        public long GetUserId(string aspuserId)
        {
            using (var _context = new BIWebModel())
            {
                long uID = (from c in _context.tblUsers
                               where c.ASPNetUsersID == aspuserId
                              select c.UserID)
                         .FirstOrDefault();

                return uID;
            }
        }
        public long? GetCompanyID( long userId)
        {
            using (var _context = new BIWebModel())
            {
                long? comID = (from c in _context.tblUsers
                               where c.UserID == userId
                               select c.CompanyID)
                         .FirstOrDefault();

                return comID;
            }
        }
        public bool AddUser(UserModel model)
        {
            try
            {
                using (var _context = new BIWebModel())
                {
                    tblUser tblUsers = new tblUser();

                    tblUsers.ASPNetUsersID = model.ASPNetUsersID;
                    tblUsers.UserFullName = model.UserFullName;
                    tblUsers.GroupID = model.GroupID;
                    tblUsers.blnUserAdmin = model.blnUserAdmin;
                    tblUsers.blnInactive = model.blnInactive;
                    tblUsers.blnChangePassword = 0;
                    tblUsers.CompanyID = 1;

                    _context.tblUsers.Add(tblUsers);


                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateUser(UserModel model)
        {
            try
            {
                using (var _context = new BIWebModel())
                {
                    tblUser tblUsers = _context.tblUsers.Where(x=> x.UserID == model.UserID).FirstOrDefault() ;

                    AspNetUser tblAspnetUsers = _context.AspNetUsers.Where(x => x.Id == model.ASPNetUsersID).FirstOrDefault();
                    tblAspnetUsers.PhoneNumber = model.PhoneNumber;
                    tblUsers.ASPNetUsersID = model.ASPNetUsersID;
                    tblUsers.UserFullName = model.UserFullName;
                    tblUsers.GroupID = model.GroupID;
                    tblUsers.blnUserAdmin = model.blnUserAdmin;
                    tblUsers.blnInactive = model.blnInactive;
                    tblUsers.blnChangePassword = 0;
                    tblUsers.CompanyID = 1;

                   


                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  List<Cls_Menu> LoadMenuDataTable(long strUserID)
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
                                 MenuName =    h.MenuText,
                                 QueryID=    c.QueryID
                                 };
                   
                    obj_dataTable = result.Distinct().ToList();

                  
                }
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            return obj_dataTable;


        }

        public List<Category> LoadMenu(long strUserID)
        {
            List<Category> obj_dataTable = new List<Category>();
            try
            {
                using (var db = new BIWebModel())
                {
                    var result = from a in db.tblUsers
                                 join h in db.tblGroupMenus on a.GroupID equals h.GroupID
                                 join c in db.tblQueryMains on h.MenuID equals c.MenuID
                                 join cg in db.tblQueryMains on c.ConnectionID equals cg.ConnectionID
                                 where a.UserID == strUserID
                                 select new Category
                                 {
                                     CategoryName = h.MenuText,
                                     CategoryID = c.QueryID
                                 };

                    obj_dataTable = result.Distinct().ToList();


                }
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            return obj_dataTable;


        }


        public void Dispose()
        {
           /// _context.Dispose() ;
           // throw new NotImplementedException();
        }
    }
}
