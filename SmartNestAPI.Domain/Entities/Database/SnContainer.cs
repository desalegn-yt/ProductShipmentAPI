using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnContainer
    {
        public decimal Weight { get; set; }
        public decimal Capacity { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public bool IsVisible { get; set; }
        public string Images { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? AdminNote { get; set; }
        public int PreorderQty { get; set; }
        public bool Preorder { get; set; }
        public string PreorderText { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
