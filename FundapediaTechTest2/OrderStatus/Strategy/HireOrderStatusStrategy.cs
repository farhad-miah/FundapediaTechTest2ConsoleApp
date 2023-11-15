using FundapediaTechTest2.OrderStatus.Enum;

namespace FundapediaTechTest2.OrderStatus.Strategy
{
    public class HireOrderStatusStrategy : BaseOrderStatusStrategy
    {
        public override Status GetOrderStatus(bool isRushOrder, bool isNewCustomer, bool isLargeOrder)
        {
            if (isLargeOrder && isRushOrder)
            {
                return Status.Closed;
            }

            return GetCommonStatus(isRushOrder, isNewCustomer, isLargeOrder);
        }
    }
}
