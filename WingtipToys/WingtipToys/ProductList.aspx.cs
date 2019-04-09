using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //QueryStringAttribute class in the System.Web.ModelBinding namespace is used to retrieve the value of the query string variable id
        //This instructs model binding to try to bind a value from the query string to the categoryId parameter at run time.
        //The sources of values for these methods are referred to as value providers (such as QueryString), 
        //and the parameter attributes that indicate which value provider to use are referred to as value provider attributes (such as id).
        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
    }
}