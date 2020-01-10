using System.ComponentModel.DataAnnotations;
using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.EntityFrameworkCore.Campaigns
{
    public class Campaign : Entity
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public double Discount { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public DiscountType DiscountType { get; set; }

        public Campaign()
        {
            IsActive = true;
        }
    }
}
