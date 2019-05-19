using ABC_Website.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        CategoryBLL category_bll = new CategoryBLL();
        AdminBLL admin_bll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //FillMenu();
            }
            if (Session["login"] != null)
            {
                lblWelcome.Text = "Welcome " + Session["username"];
                lblUsername.Text = "Fullname: " + Session["username"];
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                txtUsername.Visible = false;
                btnLogout.Visible = true;
                btnLogin.Visible = false;
                Table1.Visible = true;
            }
        }
        //private void FillMenu()
        //{
        //    gvwMenu.DataSource = category_bll.Select();
        //    gvwMenu.DataBind();
        //}
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (admin_bll.checkLogin(username, password))
            {
                Session["login"] = "true";
                Session["username"] = username;
                lblWelcome.Text = "Welcome " + Session["username"];
                lblUsername.Text = "Fullname: " + Session["username"];
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                txtUsername.Visible = false;
                btnLogout.Visible = true;
                btnLogin.Visible = false;
                Table1.Visible = true;
            }
            else
            {
                lblWelcome.Text = "Incorect username or password!";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Response.Redirect("/Home.aspx?id=1");
            }
            if (DropDownList1.SelectedValue == "2")
            {
                Response.Redirect("/Home.aspx?id=2");
            }
            if (DropDownList1.SelectedValue == "3")
            {
                Response.Redirect("/Home.aspx?id=3");
            }
            if (DropDownList1.SelectedValue == "4")
            {
                Response.Redirect("/Home.aspx?id=4");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["username"] = "";
            lblWelcome.Text = "Welcome to ABC Shop";
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtUsername.Visible = true;
            btnLogout.Visible = false;
            btnLogin.Visible = true;
            Table1.Visible = false;
        }
    }
}