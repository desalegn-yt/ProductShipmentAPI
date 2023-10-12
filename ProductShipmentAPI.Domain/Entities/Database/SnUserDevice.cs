using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class SnUserDevice
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
