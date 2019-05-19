using ABC_Website.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website.UserControls
{
    public partial class Home : System.Web.UI.UserControl
    {
        ProductBLL bll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        private void FillData()
        {
            dlProducts.DataSource = bll.Select();
            dlProducts.DataBind();
        }
    }
}