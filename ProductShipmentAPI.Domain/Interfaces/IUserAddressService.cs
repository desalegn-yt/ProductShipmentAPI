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
    public interface IUserAddressService
    {
        bool AddUserAddressRecord(UserAddressReq userAddress, string clientID);
        bool UpdateUserAddressRecord(UserAddressReq userAddress);
        bool DeleteUserAddressRecord(Guid id);
        UserAddressRes GetUserAddressSingleRecord(Guid id);
        List<UserAddressRes> GetUserAddressRecords(string clientID);
    }
}
