using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public class ShoppingListReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public Guid? ContainerId { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public DateOnly? DateCreated { get; set; } = new DateOnly(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
    }
}
