using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public class ShoppingListReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Guid UsercontainerId { get; set; }
        public string? RuleId { get; set; }
        public string? Reason { get; set; }
        public string? UserContainerName { get; set; }
        public string? UserContainerPhoto { get; set; }
        public Guid UserId { get; set; } = Guid.NewGuid();
        public DateOnly? DateCreated { get; set; } = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        public double ProductPrice { get; set; }
        public string? ProductName { get; set; }
    }
}
