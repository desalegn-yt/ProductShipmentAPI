using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnUserContainer
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
    }
}
