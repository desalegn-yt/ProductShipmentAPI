using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShipmentAPI.Domain.Interfaces
{
    public interface IOrderService
    {
        string AddOrderRecord(OrderReq order, string clientID);
        bool UpdateOrderRecord(OrderReq order);
        bool DeleteOrderRecord(Guid id);
        OrderRes GetOrderSingleRecord(Guid id);
        List<OrderRes> GetOrderRecords(string clientId);
    }
}
