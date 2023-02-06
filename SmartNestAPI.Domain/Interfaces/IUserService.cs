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
    public interface IUserService
    {
        bool AddUserRecord(UserReq order);
        bool UpdateUserRecord(UserReq order, string clientID);
        bool DeleteUserRecord(Guid id);
        UserRes GetUserSingleRecord(Guid id);
        UserRes GetUserRecord(string clientId);
    }
}
