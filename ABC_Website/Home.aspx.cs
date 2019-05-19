using ABC_Website.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductBLL product_bll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillList();
            }
        }
        private void FillList()
        {
            int id = 0;
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == 0)
            {
                dlProducts.DataSource = product_bll.Select();
                dlProducts.DataBind();
            }
            if (id == 1)
            {
                dlProducts.DataSource = product_bll.Search1();
                dlProducts.DataBind();
            }
            if (id == 2)
            {
                dlProducts.DataSource = product_bll.Search2();
                dlProducts.DataBind();
            }
            if (id == 3)
            {
                dlProducts.DataSource = product_bll.Search3();
                dlProducts.DataBind();
            }
            if (id == 4)
            {
                dlProducts.DataSource = product_bll.Search4();
                dlProducts.DataBind();
            }
        }
    }
}