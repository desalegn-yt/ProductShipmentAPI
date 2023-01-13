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
    public interface IUserAddressService
    {
        void AddUserAddressRecord(UserAddressReq userAddress);
        void UpdateUserAddressRecord(UserAddressReq userAddress);
        void DeleteUserAddressRecord(Guid id);
        UserAddressRes GetUserAddressSingleRecord(Guid id);
        List<UserAddressRes> GetUserAddressRecords();
    }
}
