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
    public interface IUserPaymentMethodService
    {
        void AddUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod);
        void UpdateUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod);
        void DeleteUserPaymentMethodRecord(Guid id);
        UserPaymentMethodRes GetUserPaymentMethodSingleRecord(Guid id);
        List<UserPaymentMethodRes> GetUserPaymentMethodRecords();
    }
}
