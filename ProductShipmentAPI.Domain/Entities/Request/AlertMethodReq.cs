using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class AlertMethodReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
