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
    public partial class Default : System.Web.UI.Page
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
        private void ClearInput()
        {
            //txtCategory.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            //txtImage.Text = "";
            txtStatus.Text = "";
            txtDetail.Text = "";
            //txtCategory.Enabled = true;
        }
        private void EnableButton(bool value)
        {
            btnAdd.Enabled = value;
            btnDelete.Enabled = !btnAdd.Enabled;
            btnUpdate.Enabled = !btnAdd.Enabled;
        }
        private void FillData()
        {
            gvwProduct.DataSource = bll.Select();
            gvwProduct.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.product_category = Convert.ToInt32(ddlCategory.SelectedValue);
            p.product_name = txtName.Text;
            p.product_price = Convert.ToDouble(txtPrice.Text);
            p.product_image = imgUpload.ImageUrl;
            p.product_status = txtStatus.Text;
            p.product_detail = txtDetail.Text;
            bll.Add(p);
            lblMessage.Text = "Add Product successfully!";
            FillData();
            ClearInput();
        }
        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            Product p = bll.SearchById(Session["id"].ToString());
            
            //txtCategory.Text = p.product_category.ToString();
            txtName.Text = p.product_name;
            txtPrice.Text = p.product_price.ToString();
            txtStatus.Text = p.product_status;
            txtDetail.Text = p.product_detail;

            EnableButton(false);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.product_id = Convert.ToInt32(Session["id"]);
            //p.product_category = Convert.ToInt32(txtCategory.Text);
            p.product_name = txtName.Text;
            p.product_price = Convert.ToDouble(txtPrice.Text);
            p.product_image = imgUpload.ImageUrl;
            p.product_status = txtStatus.Text;
            p.product_detail = txtDetail.Text;
            bll.Update(p);
            lblMessage.Text = "Update Product successfully!";
            FillData();
            ClearInput();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.product_id = Convert.ToInt32(Session["id"]);
            //p.product_category = Convert.ToInt32(txtCategory.Text);
            p.product_name = txtName.Text;
            p.product_price = Convert.ToDouble(txtPrice.Text);
            p.product_image = imgUpload.ImageUrl;
            p.product_status = txtStatus.Text;
            p.product_detail = txtDetail.Text;
            bll.Delete(p);
            lblMessage.Text = "Delete Product successfully!";
            FillData();
            ClearInput();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
            EnableButton(true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string fileUploadImage = Path.GetFileName(FileUpload.PostedFile.FileName);
                FileUpload.SaveAs(Server.MapPath("~/images/" + fileUploadImage));
                imgUpload.ImageUrl = "~/images/" + fileUploadImage;
                imgUpload.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            Product p = bll.SearchById(id);
            if (p != null)
            {
                lblMessage.Text = "Product found!";
                //txtCategory.Text = p.product_category.ToString();
                txtDetail.Text = p.product_detail;
                txtName.Text = p.product_name;
                txtPrice.Text = p.product_price.ToString();
                txtStatus.Text = p.product_status;
            }
            else if (p == null)
            {
                lblMessage.Text = "Product not found!";
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}