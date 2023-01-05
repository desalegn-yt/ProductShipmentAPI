using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class CategoryReq
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrderNumber { get; set; }
        public bool IsVisible { get; set; }
    }
}
