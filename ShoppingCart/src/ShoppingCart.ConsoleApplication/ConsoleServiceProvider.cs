using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.EntityFrameworkCore.Extensions;

namespace ShoppingCart.ConsoleApplication
{
    class ConsoleServiceProvider
    {
        public ServiceProvider InitializeServices()
        {
            var services = new ServiceCollection();
            services.RegisterDataLayerForTest();

            return services.BuildServiceProvider();
        }
    }
}
