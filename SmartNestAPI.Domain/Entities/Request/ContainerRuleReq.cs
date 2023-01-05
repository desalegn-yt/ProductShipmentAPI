using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class ContainerRuleReq
    {
        public Guid Id { get; set; }
        public Guid? ContainerId { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; } = null!;
        public Guid ProductId { get; set; }
        public int? ContentLevel { get; set; }
        public int? ExpiryInDays { get; set; }
        public Guid? NotificationId { get; set; }
        public string MetricTypes { get; set; } = null!;
    }
}
