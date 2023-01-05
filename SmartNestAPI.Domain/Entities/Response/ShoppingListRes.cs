using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ShoppingListRes
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ContainerId { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public DateOnly? DateCreated { get; set; }
    }
}
