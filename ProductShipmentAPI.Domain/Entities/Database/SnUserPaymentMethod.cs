using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class SnUserPaymentMethod
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Default { get; set; }
        public Guid? UserId { get; set; }
        public string? CardToken { get; set; }
        public string? LastFourDights { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
