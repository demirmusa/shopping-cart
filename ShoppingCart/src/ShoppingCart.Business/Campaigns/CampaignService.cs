using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.Business.Campaigns
{
    public class CampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public void GetAvailableCampaigns()
        {
        }
    }
}
