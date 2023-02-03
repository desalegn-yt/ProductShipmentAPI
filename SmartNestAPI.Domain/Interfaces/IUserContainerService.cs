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
    public interface IUserContainerService
    {
        bool AddUserContainerRecord(UserContainerReq container);
        bool UpdateUserContainerRecord(UserContainerReq container);
        bool DeleteUserContainerRecord(Guid id);
        UserContainerRes GetUserContainerSingleRecord(Guid id);
        List<UserContainerRes> GetUserContainerRecords(string clientId);
    }
}
