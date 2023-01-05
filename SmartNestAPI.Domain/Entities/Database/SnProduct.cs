using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnProduct
    {
        public string Name { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
