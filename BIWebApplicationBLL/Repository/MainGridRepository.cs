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
   public class MainGridRepository: IMainGridRepository
    {
        public List<MainGrid> LoadQueryInfo(long queryId)
        {
            using (var _context = new BIWebModel())
            {
                

                var queryInfo = from p in _context.tblQueryMains
                              join pType in _context.tblQueryConnections
                              on p.ConnectionID equals pType.ConnectionID
                              where p.QueryID == queryId
                              select new MainGrid { strConnection = pType.ConnectionValue, strQuery = p.QueryFrom };

                return queryInfo.Distinct().ToList();
            }
        }
        public List<UserParameters> LoadUserParameters(long queryId,long userId)
        {
            using (var _context = new BIWebModel())
            {


                var queryInfo = from p in _context.tblUsersQueryParameters
                                join pType in _context.tblUsersQueryParametersBridges
                                on p.ParameterID equals pType.ParameterID
                                join pT in _context.tblQueryParameters
                               on pType.ParameterID equals pT.ParameterID
                                where pType.QueryID == queryId && p.UserID == userId
                                select new UserParameters { ParameterName = pT.ParameterName, ParameterType = pT.ParameterType, ParameterValue = p.ParameterValue };

                return queryInfo.Distinct().ToList();
            }
        }

        public List<QueryUserVariables> LoadQueryUserVariables(long queryId)
        {
            using (var _context = new BIWebModel())
            {


                var queryInfo = from p in _context.tblQueryMains
                                join pType in _context.tblQueryConnections
                                on p.ConnectionID equals pType.ConnectionID
                                where p.QueryID == queryId 
                                select new QueryUserVariables { ConnectionValue = pType.ConnectionValue, QueryFrom = p.QueryFrom, DetailQueryID = p.DetailQueryID };

                return queryInfo.Distinct().ToList();
            }
        }

        public List<CreateColumn> CreateColumns(long queryId)
        {
            using (var _context = new BIWebModel())
            {

                var queryInfo = from p in _context.tblQueryColumns
                                where p.QueryID == queryId
                                select new CreateColumn { ColumnName = p.ColumnName, ColumnHeader = p.ColumnHeader, ColumnWidth = p.ColumnWidth, DetailColumn = p.DetailColumn, ColumnFormat = p.ColumnFormat };

                return queryInfo.Distinct().ToList();
            }
        }

        public List<CreateColumnDataFormatValue> CreateColumnDataFormatValues(long queryId)
        {
            using (var _context = new BIWebModel())
            {

                var queryInfo = from p in _context.tblQueryColumns
                                join pType in _context.tblQueryColumnsDataFormats
                                on p.ColumnID equals pType.ColumnID
                                where p.QueryID == queryId
                                select new CreateColumnDataFormatValue { ColumnName = p.ColumnName, ColumnDataFormula = pType.ColumnDataFormula, ColumnDataFormatForeColor = pType.ColumnDataFormatForeColor, ColumnDataFormatBackColor = pType.ColumnDataFormatBackColor };

                return queryInfo.Distinct().ToList();
            }
        }
    }
}
