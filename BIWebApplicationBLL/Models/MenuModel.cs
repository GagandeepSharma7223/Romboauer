using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

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
            NavigateUrl = navigateUrl;
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

    public class CategoriesData : ItemsData {

        List<Category> testlst = new List<Category> { new Category {CategoryID = 1,CategoryName= "Test" } };

        public override IEnumerable Data {
            get { return testlst.Select(c => new CategoryData(c)); }
        }
    }

    public class Category{
        public int CategoryID { get; set; }
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
            return true;
        }
        //protected override IHierarchicalEnumerable CreateChildren()
        //{
        //    return new ProductsData(Category.CategoryID);
        //}
    }
}
