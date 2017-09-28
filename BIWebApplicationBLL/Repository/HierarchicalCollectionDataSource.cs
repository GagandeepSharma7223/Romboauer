using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BIWebApplicationBLL.Repository
{
    public class HierarchicalCollectionDataSource : HierarchicalDataSourceControl, IHierarchicalDataSource
    {
        protected override HierarchicalDataSourceView GetHierarchicalView(string viewPath)
        {
            return new HierarchicalCollectionDataSourceView();
        }
    }

    public class HierarchicalCollectionDataSourceView : HierarchicalDataSourceView
    {
        public override IHierarchicalEnumerable Select()
        {
            CategoryHierarchicalEnumerable collection = new CategoryHierarchicalEnumerable();
            long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
            UserRepository repo = new UserRepository();
             
            foreach (Cls_Menu category in (repo.LoadMenuDataTable(userId)))
            {
                
                    collection.Add(category);
            }

            return collection;
        }
    }

    public class CategoryHierarchicalEnumerable : List<Cls_Menu>, IHierarchicalEnumerable
    {
        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }
    }

    public class Cls_MenuNew : IHierarchyData
    {
        public int _MenuID { get; set; }
        public int _QueryID { get; set; }
        public string _MenuName { get; set; }

        public Cls_MenuNew(int CategoryId, int ParentId, string Name)
        {
            this._QueryID = _QueryID;
            this._MenuID = _MenuID;
            this._MenuName = _MenuName;
        }

        public IHierarchicalEnumerable GetChildren()
        {
            CategoryHierarchicalEnumerable children = new CategoryHierarchicalEnumerable();
            long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
            UserRepository repo = new UserRepository();

            foreach (Cls_Menu category in (repo.LoadMenuDataTable(userId)))
            {
                
                    children.Add(category);
                
            }

            return children;

        }

        public IHierarchyData GetParent()
        {
            long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
            UserRepository repo = new UserRepository();

            foreach (Cls_Menu category in (repo.LoadMenuDataTable(userId)))
            {
               
                   // return category;
            }

            return null;
        }

        public bool HasChildren
        {
            get
            {
                List<Cls_Menu> children = GetChildren() as List<Cls_Menu>;
                return children.Count > 0;
            }
        }

        public object Item
        {
            get { return this; }
        }

        public string Path
        {
            get { return this._QueryID.ToString(); }
        }

        public string Type
        {
            get { return this.GetType().ToString(); }
        }

        public override string ToString()
        {
            return this._MenuName;
        }
    }
}
