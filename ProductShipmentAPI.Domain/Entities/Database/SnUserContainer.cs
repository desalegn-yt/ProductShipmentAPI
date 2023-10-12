using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class SnUserContainer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? RefId { get; set; }
        public Guid? ProductId { get; set; }
        public int? CurrentLevel { get; set; }
        public Guid UserId { get; set; }
    }
}
