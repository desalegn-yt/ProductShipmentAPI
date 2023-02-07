using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnUserAddress
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Suburb { get; set; }
        public string? Postcode { get; set; }
        public string? ContactNumber { get; set; }
    }
}
