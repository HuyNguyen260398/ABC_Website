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
    public partial class OrderManagement : System.Web.UI.Page
    {
        OrderBLL bll = new OrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
                lblMessage.Text = "";
                EnableButton(false);
            }
        }
        private void FillData()
        {
            gvwOrder.DataSource = bll.Select();
            gvwOrder.DataBind();
        }
        private void EnableButton(bool value)
        {
            btnUpdate.Enabled = value;
            btnClear.Enabled = btnUpdate.Enabled;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            Order o = bll.SearchById(Session["id"].ToString());
            txtCustomer.Text = o.Customer;
            Session["date"] = o.Date.ToShortDateString();
            txtPrice.Text = o.Total_Payment.ToString();
            ddlStatus.SelectedValue = o.Status;
            EnableButton(true);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Order o = new Order()
            {
                ID = Convert.ToInt32(Session["id"]),
                Customer = txtCustomer.Text,
                Date = Convert.ToDateTime(Session["date"]),
                Total_Payment = Convert.ToDouble(txtPrice.Text),
                Status = ddlStatus.SelectedValue
            };
            bll.Update(o);
            lblMessage.Text = "Update order successfully!";
            FillData();
            EnableButton(false);
            txtCustomer.Text = txtDate.Text = txtPrice.Text = "";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = "";
            txtPrice.Text = "";
            EnableButton(false);
        }
    }
}