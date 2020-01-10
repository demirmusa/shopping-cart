using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingCart.EntityFrameworkCore.Extensions
{
    public static class EntityFrameworkCoreDependencyInjectionExtensions
    {
        public static void RegisterDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void RegisterDataLayerForTest(this IServiceCollection services)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlite("Data Source=:memory:"));

            EnsureShoppingCartDbContextDbCreated();
        }

        private static void EnsureShoppingCartDbContextDbCreated()
        {
            var builder = new DbContextOptionsBuilder<ShoppingCartDbContext>();

            using (var inMemorySqlite = new SqliteConnection("Data Source=:memory:"))
            {
                builder.UseSqlite(inMemorySqlite);

                inMemorySqlite.Open();

                var context = new ShoppingCartDbContext(builder.Options);
                context.Database.EnsureCreated();
            }
        }
    }
}
