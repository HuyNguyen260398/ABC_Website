using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ABC_Website.Models;

namespace ABC_Website.DAO
{
    public class ProductDAO : IProductDAO
    {
        public ProductDAO()
        {

        }

        ~ProductDAO()
        {
            ConnectDB.CloseConnection();
        }
        public bool Add(Product p)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Product Values " + "(@category, @name, @detail, @image, @status, @price)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@category", Convert.ToInt32(p.product_category));
                    cmd.Parameters.AddWithValue("@name", p.product_name);
                    cmd.Parameters.AddWithValue("@detail", p.product_detail);
                    cmd.Parameters.AddWithValue("@image", p.product_image);
                    cmd.Parameters.AddWithValue("@status", p.product_status);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(p.product_price));
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Delete(Product p)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "DELETE FROM Product WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", p.product_id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Product SearchById(string id)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader red = cmd.ExecuteReader();

                    Product p = new Product();
                    if (red.Read())
                    {
                        p.product_id = Convert.ToInt32(red[0].ToString());
                        p.product_category = Convert.ToInt32(red[1].ToString());
                        p.product_name = red[2].ToString();
                        p.product_detail = red[3].ToString();
                        p.product_image = red[4].ToString();
                        p.product_status = red[5].ToString();
                        p.product_price = Convert.ToDouble(red[6].ToString());
                    }
                    red.Close();
                    return p;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable Filter(int id)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE Catefory_ID = @id";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable SearchByRange1()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE Price BETWEEN 0 AND 500";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable SearchByRange2()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE Price BETWEEN 500 AND 1000";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable SearchByRange3()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE Price BETWEEN 1000 AND 1500";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable SearchByRange4()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product WHERE Price BETWEEN 1500 AND 2000";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public DataTable Select()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Product";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Product");
                    DataTable dt = ds.Tables["Product"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Update(Product p)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Product SET ";
                    sql += "Category_ID = @category, Name = @name, Detail = @detail, Image = @image, Status = @status, ";
                    sql += "Price = @price WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@category", Convert.ToInt32(p.product_category));
                    cmd.Parameters.AddWithValue("@name", p.product_name);
                    cmd.Parameters.AddWithValue("@detail", p.product_detail);
                    cmd.Parameters.AddWithValue("@image", p.product_image);
                    cmd.Parameters.AddWithValue("@status", p.product_status);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(p.product_price));
                    cmd.Parameters.AddWithValue("@id", p.product_id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}