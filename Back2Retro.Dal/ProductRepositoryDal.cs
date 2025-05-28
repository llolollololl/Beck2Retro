using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back2Retro.Entities;
using System.Data.Entity;

namespace Back2Retro.Dal
{
    public class ProductRepositoryDal
    {
        private Back2RetroDbContext db = new Back2RetroDbContext();

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            //Этот код ищет в таблице Products продукт с идентификатором id
            //Если такой продукт есть — возвращает его. Если нет — возвращает null.
            return db.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
