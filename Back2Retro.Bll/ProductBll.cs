using System;
using System.Collections.Generic;
using Back2Retro.Entities;
using Back2Retro.Dal;

namespace Back2Retro.Bll
{
    public static class ProductBll
    {
        public static List<Product> ReadAll()
        {
            List<Product> products = ProductDal.ReadAll();
            if (products == null)
            {
                throw new Exception("No products found");
            }
            return products;
        }

        public static Product ReadOne(int id)
        {
            Product product = ProductDal.ReadOne(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }

        public static bool Create(string name, string description, decimal price, string image, Category category)
        {
            // ? означает: если name не null, то вызвать Trim(), иначе оставить null.
            name = name?.Trim();
            description = description?.Trim();

            if (!string.IsNullOrEmpty(name) && price > 0 && category != null)
            {
                Product product = new Product
                {
                    ProductName = name,
                    Description = description,
                    Price = price,
                    Image = image,
                    Category = category
                };

                return ProductDal.Create(product);
            }

            return false;
        }

        public static bool Delete(int id)
        {
            try
            {
                Product product = ProductDal.ReadOne(id);
                bool productDeleted = ProductDal.Delete(product);
                return productDeleted;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(int id, string updatedName, string updatedDescription, decimal updatedPrice, string updatedImage, Category updatedCategory)
        {
            Product product = ProductDal.ReadOne(id);

            // ? означает: если name не null, то вызвать Trim(), иначе оставить null.
            updatedName = updatedName?.Trim();
            updatedDescription = updatedDescription?.Trim();

            if (!string.IsNullOrEmpty(updatedName) && updatedPrice > 0 && updatedCategory != null)
            {
                product.ProductName = updatedName;
                product.Description = updatedDescription;
                product.Price = updatedPrice;
                product.Image = updatedImage;
                product.Category = updatedCategory;
                // bool return
                return ProductDal.Update(product);
            }

            return false;
        }
    }
}
