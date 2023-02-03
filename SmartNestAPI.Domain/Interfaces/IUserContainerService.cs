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
        void AddUserContainerRecord(UserContainerReq container);
        void UpdateUserContainerRecord(UserContainerReq container);
        void DeleteUserContainerRecord(Guid id);
        UserContainerRes GetUserContainerSingleRecord(Guid id);
        List<UserContainerRes> GetUserContainerRecords(string clientId);
    }
}
