using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnOrder
    {
        public int Qty { get; set; }
        public Guid PaymentMehtod { get; set; }
        public string PaymentRef { get; set; } = null!;
        public decimal PaidAmount { get; set; }
        public Guid ProductId { get; set; }
        public string Status { get; set; } = null!;
        public Guid UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public string OrderType { get; set; } = null!;
        public Guid? ContainerId { get; set; }
        public string? ContainerName { get; set; }
        public Guid Id { get; set; }
        public DateTime DateOrdered { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Suburb { get; set; }
        public string? Postcode { get; set; }
        public string? ContactNumber { get; set; }
    }
}
