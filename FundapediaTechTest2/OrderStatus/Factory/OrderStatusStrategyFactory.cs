using FundapediaTechTest2.OrderStatus.Enum;
using FundapediaTechTest2.OrderStatus.Interface;
using FundapediaTechTest2.OrderStatus.Strategy;

namespace FundapediaTechTest2.OrderStatus.Factory
{
    public class OrderStatusStrategyFactory : IOrderStatusStrategyFactory
    {
        public IOrderStatusStrategy GetStrategy(OrderType orderType)
        {
            return orderType switch
            {
                OrderType.Hire => new HireOrderStatusStrategy(),
                OrderType.Repair => new RepairOrderStatusStrategy(),
                _ => throw new NotSupportedException($"Order type '{orderType}' is not supported."),
            };
        }
    }
}
