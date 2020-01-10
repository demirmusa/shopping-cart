using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Shared.Campaigns
{
    public interface ICampaignRepository : IAsyncCRUDRepository<CampaignDto>
    {
        Task<List<CampaignDto>> GetActiveCampaignsByCategoryId(int categoryId);
    }
}
