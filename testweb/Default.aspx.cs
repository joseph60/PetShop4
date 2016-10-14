using PetShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testweb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            dv1.DataSource = product.GetAllProducts();
            dv1.DataBind();
        }
    }
}