using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNestAPI.Domain.Interfaces
{
    public interface IOrderService
    {
        bool AddOrderRecord(OrderReq order);
        bool UpdateOrderRecord(OrderReq order);
        bool DeleteOrderRecord(Guid id);
        OrderRes GetOrderSingleRecord(Guid id);
        List<OrderRes> GetOrderRecords(string clientId);
    }
}
