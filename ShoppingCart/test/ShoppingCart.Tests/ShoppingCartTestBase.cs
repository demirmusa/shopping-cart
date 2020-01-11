using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using ShoppingCart.EntityFrameworkCore.Extensions;

namespace ShoppingCart.Tests
{
    public class ShoppingCartTestBase
    {
        protected ServiceProvider ServiceProvider;
        private ServiceCollection _services;

        public ShoppingCartTestBase()
        {
            _services = new ServiceCollection();
            PreInitialize(_services);

            _services.RegisterDataLayerForTest();
            ServiceProvider = _services.BuildServiceProvider();
        }

        /// <summary>
        /// You can use that function to add service
        /// </summary>
        /// <param name="serviceCollection"></param>
        protected virtual void PreInitialize(ServiceCollection serviceCollection)
        {

        }

        protected T RegisterFakeTransient<T>() where T : class
        {
            var substitute = Substitute.For<T>();

            var serviceDescriptor = _services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            _services.Remove(serviceDescriptor);

            _services.AddTransient(typeof(T), provider => substitute);

            ServiceProvider = _services.BuildServiceProvider();
            return substitute;
        }

        protected T RegisterFakeSingleton<T>() where T : class
        {
            var substitute = Substitute.For<T>();

            var serviceDescriptor = _services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            _services.Remove(serviceDescriptor);

            _services.AddSingleton(typeof(T), provider => substitute);

            ServiceProvider = _services.BuildServiceProvider();
            return substitute;
        }

        protected T RegisterFakeScoped<T>() where T : class
        {
            var substitute = Substitute.For<T>();

            var serviceDescriptor = _services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            _services.Remove(serviceDescriptor);

            _services.AddScoped(typeof(T), provider => substitute);

            ServiceProvider = _services.BuildServiceProvider();
            return substitute;
        }
        
        protected async Task ShouldThrowException(Func<Task> func)
        {
            bool exceptionNotThrown = false;
            try
            {
                await func();
                exceptionNotThrown = true;
            }
            catch (Exception)
            {
            }

            if (exceptionNotThrown)
            {
                throw new Exception("Should throw exception");
            }
        }
    }
}
