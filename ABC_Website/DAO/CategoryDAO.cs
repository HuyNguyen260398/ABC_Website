using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC_Website.DAO
{
    public class CategoryDAO
    {
        public CategoryDAO()
        {

        }

        ~CategoryDAO()
        {
            ConnectDB.CloseConnection();
        }

        public DataTable Select()
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Category";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Category");
                    DataTable dt = ds.Tables["Category"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool Add(Category c)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Category Values " + "(@name, @status)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", c.Name);
                    cmd.Parameters.AddWithValue("@status", c.Status);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Delete(Category c)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "DELETE FROM Category WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool Update(Category c)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Category SET ";
                    sql += "Name = @name, Status = @status WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", c.Name);
                    cmd.Parameters.AddWithValue("@status", c.Status);
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Category SearchById(string id)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Category WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader red = cmd.ExecuteReader();

                    Category c = new Category();
                    if (red.Read())
                    {
                        c.ID = Convert.ToInt32(red[0].ToString());
                        c.Name = red[1].ToString();
                        c.Status = red[2].ToString();
                    }
                    red.Close();
                    return c;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}