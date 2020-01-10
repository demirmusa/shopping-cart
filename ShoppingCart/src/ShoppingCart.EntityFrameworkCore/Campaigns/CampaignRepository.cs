using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Shared.Campaigns;

namespace ShoppingCart.EntityFrameworkCore.Campaigns
{
    public class CampaignRepository : AsyncCRUDRepository<Campaign, CampaignDto>, ICampaignRepository
    {
        public CampaignRepository(ShoppingCartDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<CampaignDto>> GetActiveCampaignsByCategoryId(int categoryId)
        {
            var campaigns = await AsQueryable().Where(c => c.IsActive && c.CategoryId == categoryId).ToListAsync();
            return Mapper.Map<List<CampaignDto>>(campaigns);
        }
    }
}
