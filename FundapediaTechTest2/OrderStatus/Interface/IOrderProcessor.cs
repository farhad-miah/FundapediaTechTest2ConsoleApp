using FundapediaTechTest2.OrderStatus.Enum;

namespace FundapediaTechTest2.OrderStatus.Interface
{
    public interface IOrderProcessor
    {
        Status DetermineOrderStatus(bool isRushOrder, OrderType orderType, bool isNewCustomer, bool isLargeOrder);
    }
}