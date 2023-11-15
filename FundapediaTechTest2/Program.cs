using FundapediaTechTest2;
using FundapediaTechTest2.OrderStatus.Enum;
using FundapediaTechTest2.OrderStatus.Factory;
using FundapediaTechTest2.OrderStatus.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IOrderStatusStrategyFactory, OrderStatusStrategyFactory>()
                .AddScoped<IOrderProcessor, OrderProcessor>()
                .BuildServiceProvider();

            var orderProcessor = serviceProvider.GetService<IOrderProcessor>();

            var orderStatus = orderProcessor?.DetermineOrderStatus(true, OrderType.Hire, true, false);

            Console.WriteLine($"Order status: {orderStatus}");
        }
    }
}
