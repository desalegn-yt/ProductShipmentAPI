using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShipmentAPI.Domain.Entities.Request
{
    public partial class ContainerUpdateReq
    {
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
