using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class SnCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrderNumber { get; set; }
        public bool IsVisible { get; set; }
    }
}
