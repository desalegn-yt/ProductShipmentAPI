﻿using SmartNestAPI.Domain.Entities.Database;
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
        void AddUserRecord(UserReq order);
        void UpdateUserRecord(UserReq order);
        void DeleteUserRecord(Guid id);
        UserRes GetUserSingleRecord(Guid id);
        List<UserRes> GetUserRecords();
    }
}