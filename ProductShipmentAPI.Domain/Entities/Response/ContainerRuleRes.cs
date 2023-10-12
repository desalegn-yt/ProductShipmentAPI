using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class ContainerRuleRes
    {
        public Guid Id { get; set; }
        public Guid? ContainerId { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; } = null!;
        public Guid ProductId { get; set; }
        public int? ContentLevel { get; set; }
        public int? ExpiryInDays { get; set; }
        public string MetricTypes { get; set; } = null!;
    }
}
