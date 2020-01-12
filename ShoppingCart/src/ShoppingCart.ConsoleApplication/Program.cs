using System;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Shared.Campaigns;
using ShoppingCart.Shared.Categories;
using ShoppingCart.Shared.Coupons;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ConsoleServiceProvider().InitializeServices();

            var categoryRepository = serviceProvider.GetRequiredService<ICategoryRepository>();
            var productRepository = serviceProvider.GetRequiredService<IProductRepository>();
            var campaignRepository = serviceProvider.GetRequiredService<ICampaignRepository>();
            var couponRepository = serviceProvider.GetRequiredService<ICouponRepository>();
            
            var category = new CategoryDto("Food");

        }
    }
}
