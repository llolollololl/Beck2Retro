using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }

        public Product()
        {

        }

        public Product(int propductId, string propductName, string description, decimal price, string image, Category category)
        {
            ProductId = propductId;
            ProductName = propductName;
            Description = description;
            Price = price;
            Image = image;
            Category = category;
        }

    }
}
