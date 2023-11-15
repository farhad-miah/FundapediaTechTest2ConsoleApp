using FundapediaTechTest2.OrderStatus.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundapediaTechTest2.OrderStatus.Interface
{
    public interface IOrderStatusStrategy
    {
        Status GetOrderStatus(bool isRushOrder, bool isNewCustomer, bool isLargeOrder);
    }
}
