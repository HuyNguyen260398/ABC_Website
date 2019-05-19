using ABC_Website.DAO;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ABC_Website.BLL
{
    public class CategoryBLL
    {
        private CategoryDAO dao;

        public CategoryBLL()
        {
            dao = new CategoryDAO();
        }
        public DataTable Select()
        {
            return dao.Select();
        }
        public bool Add(Category c)
        {
            return dao.Add(c);
        }
        public bool Update(Category c)
        {
            return dao.Update(c);
        }
        public bool Delete(Category c)
        {
            return dao.Delete(c);
        }
        public Category SearchById(string id)
        {
            return dao.SearchById(id);
        }
    }
}