using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class UserDeviceReq
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; } = null!;
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
