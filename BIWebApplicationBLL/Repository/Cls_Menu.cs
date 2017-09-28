using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BIWebApplicationBLL.Repository
{
    public class Cls_Menu : IHierarchicalEnumerable
    {
       // private long _MenuID;
        private string _MenuName;

        private long _QueryID;

        //public long MenuID
        //{
        //    get
        //    {
        //        return this._MenuID;
        //    }
        //    set
        //    {
        //        this._MenuID = value;
        //    }
        //}
        public string MenuName
        {
            get
            {
                return this._MenuName;
            }
            set
            {
                this._MenuName = value;
            }
        }
        public long QueryID
        {
            get
            {
                return this._QueryID;
            }
            set
            {
                this._QueryID = value;
            }
        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            throw new NotImplementedException();
        }

    }
}
