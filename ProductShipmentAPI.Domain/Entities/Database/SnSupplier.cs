using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class SnSupplier
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Email { get; set; }
        public string? About { get; set; }
        public string? Website { get; set; }
        public string? ContactNumber { get; set; }
        public string? ShippingInfo { get; set; }
    }
}
