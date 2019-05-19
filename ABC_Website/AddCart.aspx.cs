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

    public partial class AddCart : System.Web.UI.Page
    {
        public List<CartItem> MyShoppingCart
        {
            get
            {
                return Session["shoppingcart"] as List<CartItem>;
            }
            set
            {
                Session["shoppingcart"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int maSanPham = 0;
            bool check = true;
            if (Request.QueryString["id"] != null)
            {
                maSanPham = int.Parse(Request.QueryString["id"]);
                check = false;
            }
            else if (Request.QueryString["id"] == null)
            {
                maSanPham = int.Parse(Session["pid"].ToString());
            }
            if (HttpContext.Current.Session["shoppingcart"] == null)
            {
                Session.Add("shoppingcart", new List<CartItem>());
            }
            CartItem newItem = MyShoppingCart.FirstOrDefault(m => m.pro_id == maSanPham);
            if (newItem != null)
            {
                newItem.quantity++;
            }
            else
            {
                ProductBLL bll = new ProductBLL();
                Product p = bll.SearchById(maSanPham.ToString());
                newItem = new CartItem()
                {
                    pro_id = maSanPham,
                    pro_name = p.product_name,
                    pro_price = p.product_price,
                    pro_image = p.product_image,
                    quantity = 1
                };
                MyShoppingCart.Add(newItem);
            }

            Session["quantity"] = MyShoppingCart.Sum(m => m.quantity);
            Session["total_payment"] = MyShoppingCart.Sum(m => m.total);
            

            if (check)
            {
                Response.Redirect("ProductDetail.aspx?id=" + maSanPham);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }

        }
    }
}
