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
    public class UserRepository : IUserRepository
    {
        private readonly BIWebModel _context;
        public UserRepository()
        {
            _context = new BIWebModel();
        }

        public List<UserModel> GetUsers()
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

        public List<GroupModel> GetGroups()
        {
            return _context.tblGroups.Select(x => new GroupModel
            {
                GroupID = x.GroupID,
                GroupName = x.GroupName
            }).ToList();
        }

        public bool AddUser(UserModel model)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
