using BIWebApplicationBLL.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using BIWebApplicationBLL.Repository;
using BIWebApplicationDAL;

namespace BIWebApplicationBLL.Models
{
    public class MenuModel
    {
    }

    public abstract class ItemsData : IHierarchicalEnumerable, IEnumerable
    {
        public ItemsData()
        {
        }

        public abstract IEnumerable Data { get; }

        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }
        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return (IHierarchyData)enumeratedItem;
        }
    }
    public class ItemData : IHierarchyData
    {
        public string Text { get; protected set; }
        public string NavigateUrl { get; protected set; }

        public ItemData(string text, string navigateUrl)
        {
            Text = text;
            NavigateUrl = navigateUrl.Contains("10") ? "Admin/AdminUsers" : navigateUrl;
        }

        // IHierarchyData
        bool IHierarchyData.HasChildren
        {
            get { return HasChildren(); }
        }
        object IHierarchyData.Item
        {
            get { return this; }
        }
        string IHierarchyData.Path
        {
            get { return NavigateUrl; }
        }
        string IHierarchyData.Type
        {
            get { return GetType().ToString(); }
        }
        IHierarchicalEnumerable IHierarchyData.GetChildren()
        {
            return CreateChildren();
        }
        IHierarchyData IHierarchyData.GetParent()
        {
            return null;
        }

        protected virtual bool HasChildren()
        {
            return false;
        }
        protected virtual IHierarchicalEnumerable CreateChildren()
        {
            return null;
        }
    }

    public class CategoriesData : ItemsData
    {
        //UserRepository repcls = new UserRepository();
        //private IUserRepository repo;



        List<Category> testlst = LoadMenu(Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]));//new List<Category> { new Category {CategoryID = 1,CategoryName= "Test" } };


        public static List<Category> LoadMenu(long strUserID)
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

                    long userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                    if (userId == 1)
                    {

                        obj_dataTable.Add(new Category() { CategoryName = "User Admin", CategoryID = 10 });
                    }
                }
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message, MsgBoxStyle.Critical, "AddUpdateBridgeValues General Error");
            }
            return obj_dataTable;


        }

        public override IEnumerable Data
        {
            get { return testlst.Select(c => new CategoryData(c)); }
        }
    }

    public class Category
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryData : ItemData
    {
        public Category Category { get; protected set; }

        public CategoryData(Category category)
            : base(category.CategoryName, "?CategoryID=" + category.CategoryID)
        {
            Category = category;
        }

        protected override bool HasChildren()
        {
            return false;
        }
        //protected override IHierarchicalEnumerable CreateChildren()
        //{
        //    return new ProductsData(Category.CategoryID);
        //}
    }
}
