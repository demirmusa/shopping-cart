namespace ShoppingCart.Shared.Campaigns
{
    public class CampaignDto : EntityDto
    {
        public int CategoryId { get; set; }

        public double Discount { get; set; }

        public bool IsActive { get; set; }

        public DiscountType DiscountType { get; set; }

        public CampaignDto()
        {
            IsActive = true;
        }
    }
}
