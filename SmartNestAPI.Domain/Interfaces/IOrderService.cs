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
        void AddOrderRecord(OrderReq order);
        void UpdateOrderRecord(OrderReq order);
        void DeleteOrderRecord(Guid id);
        OrderRes GetOrderSingleRecord(Guid id);
        List<OrderRes> GetOrderRecords(string clientId);
    }
}
