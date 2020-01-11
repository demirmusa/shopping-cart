using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.Shared.Coupons
{
    public class CouponDto : EntityDto
    {
        public double MinimumAmount { get; set; }

        public double Discount { get; set; }

        public DiscountType DiscountType { get; set; }

        public bool IsActive { get; set; }
    }
}
