using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class UserPaymentMethodReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public bool? Default { get; set; }
        public Guid? UserId { get; set; }
        public string? CardToken { get; set; }
    }
}
