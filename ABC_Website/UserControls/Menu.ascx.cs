using ABC_Website.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website.UserControls
{
    public partial class Menu : System.Web.UI.UserControl
    {
        CategoryBLL bll = new CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        private void FillData()
        {
            gvwMenu.DataSource = bll.Select();
            gvwMenu.DataBind();
        }
    }
}