using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.EntityFrameworkCore.Categories
{
    public class Category : Entity
    {
        [Required]
        public string Title { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
