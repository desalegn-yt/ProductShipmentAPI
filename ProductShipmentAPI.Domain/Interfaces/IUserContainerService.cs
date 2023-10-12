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
    public interface IUserContainerService
    {
        bool AddUserContainerRecord(UserContainerReq container, string clientID);
        bool UpdateUserContainerRecord(UserContainerReq container);
        bool DeleteUserContainerRecord(Guid id);
        UserContainerDetailRes GetUserContainerSingleRecord(Guid id);
        List<UserContainerRes> GetUserContainerRecords(string clientId);
    }
}
