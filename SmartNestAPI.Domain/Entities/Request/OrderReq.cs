using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class OrderReq
    {
        public int Qty { get; set; }
        public Guid PaymentMehtod { get; set; }
        public string PaymentRef { get; set; } = null!;
        public decimal PaidAmount { get; set; }
        public Guid ProductId { get; set; }
        public string Status { get; set; } = null!;
        public Guid UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public Guid? ContainerId { get; set; }
        public string? ContainerName { get; set; }
        public Guid Id { get; set; }
        public DateTime DateOrdered { get; set; }
    }
}
