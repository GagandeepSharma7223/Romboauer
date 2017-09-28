using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Interface
{
    public interface IUserRepository
    {
        List<UserModel> GetUsers();
        List<GroupModel> GetGroups();
        bool AddUser(UserModel model);
        long? GetCompanyID(long userId);
        long GetUserId(string aspuserId);
        bool UpdateUser(UserModel model);
        List<Cls_Menu> LoadMenuDataTable(long strUserID);
    }
}
