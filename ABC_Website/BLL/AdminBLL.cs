using ABC_Website.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Website.BLL
{
    public class AdminBLL
    {
        private Login dao;

        public AdminBLL()
        {
            dao = new Login();
        }
        public bool checkLogin(string username, string password)
        {
            return dao.checkLogin(username, password);
        }
    }
}