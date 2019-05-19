using ABC_Website.DAO;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ABC_Website.BLL
{
    public class OrderBLL
    {
        private OrderDAO dao;
        public OrderBLL()
        {
            dao = new OrderDAO();
        }
        public DataTable Select()
        {
            return dao.Select();
        }
        public bool Add(Order o)
        {
            return dao.Add(o);
        }
        public bool Update(Order o)
        {
            return dao.Update(o);
        }
        public bool Delete(Order o)
        {
            return dao.Delete(o);
        }
        public Order SearchById(string id)
        {
            return dao.SearchById(id);
        }
    }
}