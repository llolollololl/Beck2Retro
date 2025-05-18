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
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name can't be longer than 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters.")]
        public string Description { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image URL or file name is required.")]
        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Category is required.")]
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
