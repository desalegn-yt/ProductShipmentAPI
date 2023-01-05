using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnUserPaymentMethod
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? Default { get; set; }
        public Guid? UserId { get; set; }
        public string? CardToken { get; set; }
    }
}
