using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.EntityFrameworkCore.Products
{
    public class Product : Entity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
