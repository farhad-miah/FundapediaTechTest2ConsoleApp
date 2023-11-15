using FundapediaTechTest2.OrderStatus.Enum;
using FundapediaTechTest2.OrderStatus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundapediaTechTest2.OrderStatus.Strategy
{
    public abstract class BaseOrderStatusStrategy : IOrderStatusStrategy
    {
        public abstract Status GetOrderStatus(bool isRushOrder, bool isNewCustomer, bool isLargeOrder);

        protected Status GetCommonStatus(bool isRushOrder, bool isNewCustomer, bool isLargeOrder)
        {
            if (isRushOrder && isNewCustomer)
            {
                return Status.AuthorisationRequired;
            }

            return Status.Confirmed;
        }
    }
}
