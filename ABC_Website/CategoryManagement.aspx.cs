using ABC_Website.BLL;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class CategoryManage : System.Web.UI.Page
    {
        CategoryBLL bll = new CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
                lblMessage.Text = "";
                EnableButton(true);
            }
        }
        private void FillData()
        {
            gvwCategory.DataSource = bll.Select();
            gvwCategory.DataBind();
        }
        private void EnableButton(bool value)
        {
            btnAdd.Enabled = value;
            btnDelete.Enabled = !btnAdd.Enabled;
            btnUpdate.Enabled = !btnAdd.Enabled;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            Category c = bll.SearchById(Session["id"].ToString());
            txtName.Text = c.Name;
            txtStatus.Text = c.Status;
            EnableButton(false);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtStatus.Text != "")
            {
                lblName.Text = "This field cannot be blank!";
                lblStatus.Text = "";
            }
            else if (txtStatus.Text == "" && txtName.Text != "")
            {
                lblStatus.Text = "This field cannot be blank!";
                lblName.Text = "";
            }
            else if (txtName.Text == "" && txtStatus.Text == "")
            {
                lblName.Text = lblStatus.Text = "This field cannot be blank!";
            }
            else if(txtName.Text != "" && txtStatus.Text != "")
            {
                Category c = new Category();
                c.Name = txtName.Text;
                c.Status = txtStatus.Text;
                bll.Add(c);
                lblMessage.Text = "Add new category successfully!";
                lblName.Text = lblStatus.Text = "";
                FillData();
                txtName.Text = "";
                txtStatus.Text = "";
                EnableButton(true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.ID = Convert.ToInt32(Session["id"]);
            c.Name = txtName.Text;
            c.Status = txtStatus.Text;
            bll.Update(c);
            lblMessage.Text = "Update category successfully!";
            FillData();
            EnableButton(true);
            txtName.Text = "";
            txtStatus.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.ID = Convert.ToInt32(Session["id"]);
            c.Name = txtName.Text;
            c.Status = txtStatus.Text;
            bll.Delete(c);
            lblMessage.Text = "Delete category successfully!";
            FillData();
            EnableButton(true);
            txtName.Text = "";
            txtStatus.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtStatus.Text = "";
            EnableButton(true);
        }
    }
}