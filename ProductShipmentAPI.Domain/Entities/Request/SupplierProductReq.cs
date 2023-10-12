using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public partial class SupplierProductReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? SupplierId { get; set; }
        public string? Name { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rrp { get; set; }
        public string? Description { get; set; }
        public bool? CanBuyOutStock { get; set; }
        public string? Images { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal? Reviews { get; set; }
        public int? ReviewCount { get; set; }
    }
}
