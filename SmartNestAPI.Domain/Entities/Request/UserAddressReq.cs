using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class UserAddressReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Suburb { get; set; }
        public string? Postcode { get; set; }
        public string? ContactNumber { get; set; }
    }
}
