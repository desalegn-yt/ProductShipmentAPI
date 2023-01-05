using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ProductRes
    {
        public string Name { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
