using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABC_Website.DAO
{
    public class Login
    {
        public Login()
        {

        }
        ~Login()
        {
            ConnectDB.CloseConnection();
        }
        public bool checkLogin(string username, string password)
        {
            bool valid = false;
            using (SqlConnection con = ConnectDB.StartConnection())
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Admin WHERE [Username] = @username and [Password] = @password";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return valid;
        }
    }
}