using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class CategoryReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public int OrderNumber { get; set; }
        public bool IsVisible { get; set; }
    }
}
