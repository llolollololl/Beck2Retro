using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Back2Retro.Entities;

namespace Back2Retro.Dal
{
    public static class ProductDal
    {
        
        public static List<Product> ReadAll()
        {
            using (var db = new Back2RetroDbContext())
            {
                List<Product> lstProduct = db.Products.ToList();
                return lstProduct;
            }
        }

        public static Product ReadOne(int id)
        {
            using (var db = new Back2RetroDbContext())
            {
                Product product = db.Products
                                    .Include(p => p.Category)
                                    .FirstOrDefault(p => p.ProductId == id);
                return product;
            }
        }

        public static bool Create(Product product)
        {
            using (var db = new Back2RetroDbContext())
            {
                try
                {
                    db.Products.Add(product);
                    int result = db.SaveChanges();
                    return result > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool Update(Product updatedProduct)
        {
            using (var db = new Back2RetroDbContext())
            {
                try
                {
                    db.Products.AddOrUpdate(updatedProduct);
                    int result = db.SaveChanges();
                    return result > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool Delete(Product product)
        {
            using (var db = new Back2RetroDbContext())
            {
                try
                {
                    db.Entry(product).State = EntityState.Deleted;
                    int result = db.SaveChanges();
                    return result > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
