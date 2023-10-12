using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class UserDeviceReq
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; } = null!;
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
