using ABC_Website.DLL;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ProductBLL product_bll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];
                Session["pid"] = id;

                Product p = product_bll.SearchById(id);

                imgProduct.ImageUrl = p.product_image;
                lblName.Text = p.product_name;
                lblStatus.Text = p.product_status;
                lblDetail.Text = p.product_detail;
                lblPrice.Text = p.product_price.ToString();
            }
        }
    }
}