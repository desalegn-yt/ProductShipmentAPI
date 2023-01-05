using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class AlertMethodReq
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
