using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ShoppingListRes
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UsercontainerId { get; set; }
        public string? RuleId { get; set; }
        public string? Reason { get; set; }
        public string? UserContainerName { get; set; }
        public string? UserContainerPhoto { get; set; }
        public DateOnly? DateCreated { get; set; }
        public double ProductPrice { get; set; }
        public string?  ProductName { get; set; }


    }
}
