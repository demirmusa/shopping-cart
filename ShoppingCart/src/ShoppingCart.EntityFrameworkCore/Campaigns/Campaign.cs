using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoppingCart.EntityFrameworkCore.Categories;
using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.EntityFrameworkCore.Campaigns
{
    public class Campaign : Entity
    {
        [Required]
        [Range(1, 100)]
        public double Discount { get; set; }

        [Required]
        public DiscountType DiscountType { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }

        public Campaign(int categoryId, double discount, DiscountType discountType = DiscountType.Rate)
        {
            CategoryId = categoryId;
            Discount = discount;
            DiscountType = discountType;

            IsActive = true;
        }
    }
}
