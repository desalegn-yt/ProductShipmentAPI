using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class UserPaymentMethodReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public bool? Default { get; set; }
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string? CardToken { get; set; }
        public string? LastFourDights { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
