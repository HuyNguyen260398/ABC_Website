using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ABC_Website.DAO
{
    public class ConnectDB
    {
        static SqlConnection _SqlConnection;
        public static SqlConnection StartConnection()
        {
            try
            {
                _SqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConStrDB"].ConnectionString);
                return _SqlConnection;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection CloseConnection()
        {
            _SqlConnection.Close();
            return _SqlConnection;
        }
    }
}