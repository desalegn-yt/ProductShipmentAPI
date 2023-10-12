using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class UserContainerRes
    {
        public Guid Id { get; set; }
        //public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? RefId { get; set; }
        public Guid? ProductId { get; set; }
        public int? CurrentLevel { get; set; }
        public Guid UserId { get; set; }
    }
}
