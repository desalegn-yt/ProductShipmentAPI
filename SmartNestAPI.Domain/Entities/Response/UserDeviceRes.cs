﻿using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class UserDeviceRes
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
