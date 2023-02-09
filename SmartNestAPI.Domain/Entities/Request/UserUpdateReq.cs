using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class UserUpdateReq
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
