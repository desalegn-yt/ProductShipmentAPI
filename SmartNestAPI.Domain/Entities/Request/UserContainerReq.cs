using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class UserContainerReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
    }
}
