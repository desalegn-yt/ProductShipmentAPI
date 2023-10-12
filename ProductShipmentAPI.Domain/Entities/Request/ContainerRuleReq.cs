using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class ContainerRuleReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? ContainerId { get; set; }
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = null!;
        public Guid ProductId { get; set; }
        public int? ContentLevel { get; set; }
        public int? ExpiryInDays { get; set; }
        public string MetricTypes { get; set; } = null!;
    }
}
