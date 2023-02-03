using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class SupplierReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Email { get; set; }
        public string? About { get; set; }
        public string? Website { get; set; }
        public string? ContactNumber { get; set; }
        public string? ShippingInfo { get; set; }
    }
}
