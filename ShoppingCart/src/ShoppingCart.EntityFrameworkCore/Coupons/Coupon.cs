using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.EntityFrameworkCore.Coupons
{
    public class Coupon : Entity
    {
        [Required]
        [Range(1, int.MaxValue)]
        public double MinimumAmount { get; set; }

        [Required]
        [Range(1, 100)]
        public double Discount { get; set; }

        [Required]
        public DiscountType DiscountType { get; set; }

        public bool IsActive { get; set; }

        public Coupon(double minimumAmount, double discount, DiscountType discountType)
        {
            MinimumAmount = minimumAmount;
            Discount = discount;
            DiscountType = discountType;
        }
    }
}
