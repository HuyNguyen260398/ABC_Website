using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Website.DAO
{
    interface IProductDAO
    {
        DataTable Select();
        bool Add(Product p);
        bool Update(Product p);
        bool Delete(Product p);
        Product SearchById(string id);
    }
}
