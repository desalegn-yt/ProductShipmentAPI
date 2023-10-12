using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class CategoryRes
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrderNumber { get; set; }
        public bool IsVisible { get; set; }
    }
}
