using ABC_Website.DAO;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ABC_Website.DLL
{
    public class ProductBLL
    {
        private ProductDAO dao;
        public ProductBLL()
        {
            dao = new ProductDAO();
        }
        public DataTable Select()
        {
            return dao.Select();
        }
        public DataTable Search1()
        {
            return dao.SearchByRange1();
        }
        public DataTable Search2()
        {
            return dao.SearchByRange2();
        }
        public DataTable Search3()
        {
            return dao.SearchByRange3();
        }
        public DataTable Search4()
        {
            return dao.SearchByRange4();
        }
        public bool Add(Product p)
        {
            return dao.Add(p);
        }
        public bool Update(Product p)
        {
            return dao.Update(p);
        }
        public bool Delete(Product p)
        {
            return dao.Delete(p);
        }
        public Product SearchById(string id)
        {
            return dao.SearchById(id);
        }
    }
}