using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingCart.EntityFrameworkCore.Categories;

namespace ShoppingCart.EntityFrameworkCore.Products
{
    public class Product : Entity
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Product(string title, double price, int categoryId)
        {
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
