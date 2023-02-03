using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class ProductReq
    {
        public string Name { get; set; } = null!;
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
