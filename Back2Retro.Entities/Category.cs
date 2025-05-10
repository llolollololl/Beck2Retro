using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryOfProduct { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            
        }

        public Category(int id, string categoryOfProduct, string format)
        {
            Id = id;
            CategoryOfProduct = categoryOfProduct;
            Products = new List<Product>();
        }
    }
}
