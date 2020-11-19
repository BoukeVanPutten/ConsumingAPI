using Microsoft.Extensions.DependencyInjection;
using ServiceProject.Services;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Setup DI
            var provider = ConfigureServices();

            //Start program
            var controller = provider.GetService<IController>();
            await controller.Run();
        }

        static ServiceProvider ConfigureServices()
        {
            var provider = new ServiceCollection()
                .AddScoped<IOrderFilter, OrderFilter>()
                .AddScoped<IProductSorter, ProductSorter>()
                .AddScoped<IAPIClient, APIClient>()
                .AddScoped<IProductSetter, ProductSetter>()
                .AddSingleton<IController, Controller>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
