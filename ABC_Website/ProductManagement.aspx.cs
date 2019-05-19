using ABC_Website.DLL;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        ProductBLL bll = new ProductBLL();
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
            gvwProduct.DataSource = bll.Select();
            gvwProduct.DataBind();
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
            Product p = bll.SearchById(Session["id"].ToString());
            ddlCategory.SelectedValue = p.product_category.ToString();
            txtName.Text = p.product_name;
            txtDetail.Text = p.product_detail;
            ddlStatus.SelectedValue = p.product_status;
            imgUpload.ImageUrl = p.product_image;
            imgUpload.Visible = true;
            txtPrice.Text = p.product_price.ToString();
            EnableButton(false);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "This field cannot be blank!";
            if (txtName.Text == "")
            {
                lblName.Text = error;
            }
            if (txtDetail.Text == "")
            {
                lblDetail.Text = error;
            }
            if (imgUpload.ImageUrl == null)
            {
                lblImage.Text = error;
            }
            if (txtPrice.Text == "")
            {
                lblPrice.Text = error;
            }
            if (txtName.Text != "" && txtDetail.Text != "" && txtPrice.Text != "" && imgUpload.ImageUrl != null)
            {
                Product p = new Product
                {
                    product_category = Convert.ToInt32(ddlCategory.SelectedValue),
                    product_name = txtName.Text,
                    product_detail = txtDetail.Text,
                    product_image = imgUpload.ImageUrl,
                    product_status = ddlStatus.SelectedValue,
                    product_price = Convert.ToDouble(txtPrice.Text)
                };
                bll.Add(p);
                lblMessage.Text = "Add new product successfully!";
                FillData();
                EnableButton(true);
                imgUpload.Visible = false;
                txtName.Text = txtDetail.Text = txtPrice.Text = lblName.Text = lblDetail.Text = lblImage.Text = lblPrice.Text = "";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = new Product
            {
                product_id = Convert.ToInt32(Session["id"]),
                product_category = Convert.ToInt32(ddlCategory.SelectedValue),
                product_name = txtName.Text,
                product_detail = txtDetail.Text,
                product_image = imgUpload.ImageUrl,
                product_status = ddlStatus.SelectedValue,
                product_price = Convert.ToDouble(txtPrice.Text)
            };
            bll.Update(p);
            lblMessage.Text = "Update product successfully!";
            FillData();
            EnableButton(true);
            txtName.Text = txtDetail.Text = txtPrice.Text = "";
            imgUpload.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = new Product
            {
                product_id = Convert.ToInt32(Session["id"]),
                product_category = Convert.ToInt32(ddlCategory.SelectedValue),
                product_name = txtName.Text,
                product_detail = txtDetail.Text,
                product_image = imgUpload.ImageUrl,
                product_status = ddlStatus.SelectedValue,
                product_price = Convert.ToDouble(txtPrice.Text)
            };
            bll.Delete(p);
            lblMessage.Text = "Delete product successfully!";
            FillData();
            EnableButton(true);
            txtName.Text = txtDetail.Text = txtPrice.Text = "";
            imgUpload.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = txtDetail.Text = txtPrice.Text = "";
            EnableButton(true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fileUploadImage = Path.GetFileName(FileUpload.PostedFile.FileName);
                FileUpload.SaveAs(Server.MapPath("images/" + fileUploadImage));
                imgUpload.ImageUrl = "images/" + fileUploadImage;
                imgUpload.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvwProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwProduct.PageIndex = e.NewPageIndex;
            gvwProduct.DataSource = bll.Select();
            gvwProduct.DataBind();
        }
    }
}