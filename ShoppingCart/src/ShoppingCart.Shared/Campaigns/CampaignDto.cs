namespace ShoppingCart.Shared.Campaigns
{
    public class CampaignDto : EntityDto
    {
        public int CategoryId { get; set; }

        public double Discount { get; set; }

        public bool IsActive { get; set; }

        public DiscountType DiscountType { get; set; }

        public CampaignDto(int categoryId, double discount, DiscountType discountType = DiscountType.Rate)
        {
            CategoryId = categoryId;
            Discount = discount;
            DiscountType = discountType;

            IsActive = true;
        }
    }
}
