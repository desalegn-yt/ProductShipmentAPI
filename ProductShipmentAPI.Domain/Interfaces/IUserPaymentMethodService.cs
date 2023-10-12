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
    public interface IUserPaymentMethodService
    {
        bool AddUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod, string clientID);
        bool UpdateUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod);
        bool DeleteUserPaymentMethodRecord(Guid id);
        UserPaymentMethodRes GetUserPaymentMethodSingleRecord(Guid id);
        List<UserPaymentMethodRes> GetUserPaymentMethodRecords(string clientId);
    }
}
