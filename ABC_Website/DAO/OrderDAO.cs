using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC_Website.DAO
{
    public class OrderDAO
    {
        public OrderDAO()
        {

        }
        ~OrderDAO()
        {
            ConnectDB.CloseConnection();
        }
        public bool Add(Order o)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO [Order] Values " + "(@customer, @date, @total_payment, @status)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@customer", o.Customer);
                    cmd.Parameters.AddWithValue("@date", o.Date);
                    cmd.Parameters.AddWithValue("@total_payment", Convert.ToDouble(o.Total_Payment));
                    cmd.Parameters.AddWithValue("@status", o.Status);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Delete(Order o)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "DELETE FROM [Order] WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", o.ID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Order SearchById(string id)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM [Order] WHERE ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader red = cmd.ExecuteReader();

                    Order o = new Order();
                    if (red.Read())
                    {
                        o.ID = Convert.ToInt32(red[0].ToString());
                        o.Customer = red[1].ToString();
                        o.Date = Convert.ToDateTime(red[2].ToString());
                        o.Total_Payment = Convert.ToDouble(red[3].ToString());
                        o.Status = red[4].ToString();
                    }
                    red.Close();
                    return o;
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
                    string sql = "SELECT * FROM [Order]";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Order");
                    DataTable dt = ds.Tables["Order"];
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Update(Order o)
        {
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE [Order] SET ";
                    sql += "Customer = @customer, Date = @date, Total_Payment = @total_payment, Status = @status WHERE ID = @id ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@customer", o.Customer);
                    cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(o.Date));
                    cmd.Parameters.AddWithValue("@total_payment", Convert.ToDouble(o.Total_Payment));
                    cmd.Parameters.AddWithValue("@status", o.Status);
                    cmd.Parameters.AddWithValue("@id", o.ID);
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