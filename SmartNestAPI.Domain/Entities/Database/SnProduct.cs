using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class SnProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public double Price { get; set; }

    }
}
