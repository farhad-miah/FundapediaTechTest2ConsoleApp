using FundapediaTechTest2.OrderStatus.Enum;

namespace FundapediaTechTest2.OrderStatus.Interface
{
    public interface IOrderStatusStrategyFactory
    {
        IOrderStatusStrategy GetStrategy(OrderType orderType);
    }
}