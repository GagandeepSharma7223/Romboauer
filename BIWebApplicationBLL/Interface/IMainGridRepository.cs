using BIWebApplicationBLL.Models;
using BIWebApplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Interface
{
    public interface IMainGridRepository
    {
        List<MainGrid> LoadQueryInfo(long queryId);
        List<UserParameters> LoadUserParameters(long queryId, long userId);
        List<QueryUserVariables> LoadQueryUserVariables(long queryId);
        List<CreateColumn> CreateColumns(long queryId);
        List<CreateColumnDataFormatValue> CreateColumnDataFormatValues(long queryId);
    }
}
