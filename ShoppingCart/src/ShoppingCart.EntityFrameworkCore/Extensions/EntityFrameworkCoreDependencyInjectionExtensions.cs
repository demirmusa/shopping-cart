using System.Runtime.Serialization;
using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.EntityFrameworkCore.Campaigns;
using ShoppingCart.EntityFrameworkCore.Categories;
using ShoppingCart.EntityFrameworkCore.Products;
using ShoppingCart.Shared.Campaigns;
using ShoppingCart.Shared.Categories;
using ShoppingCart.Shared.Products;

namespace ShoppingCart.EntityFrameworkCore.Extensions
{
    public static class EntityFrameworkCoreDependencyInjectionExtensions
    {
        public static void RegisterDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));
            AddServices(services);
        }

        public static void RegisterDataLayerForTest(this IServiceCollection services)
        {
            RegisterInMemorySqlLite(services);
            AddServices(services);
        }

        private static void RegisterInMemorySqlLite(IServiceCollection services)
        {
            var builder = new DbContextOptionsBuilder<ShoppingCartDbContext>();

            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            builder.UseSqlite(inMemorySqlite);

            inMemorySqlite.Open();

            var context = new ShoppingCartDbContext(builder.Options);
            context.Database.EnsureCreated();

            services.AddSingleton<DbContextOptions<ShoppingCartDbContext>>(builder.Options);
            services.AddScoped(provider => new ShoppingCartDbContext(builder.Options));
        }

        private static void AddServices(IServiceCollection services)
        {
            CreateAutoMapperMaps(services);

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
        }

        private static void CreateAutoMapperMaps(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<CategoryDto, Category>().ReverseMap();
                mc.CreateMap<CampaignDto, Campaign>().ReverseMap();
                mc.CreateMap<ProductDto, Product>().ReverseMap();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
