using BIWebApplicationBLL.Models;
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
    }
}
