using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class ContainerUpdateReq
    {
        public string Description { get; set; } = null!;
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Photo { get; set; }
        public Guid? ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "Current level value must be between 1 and 100.")]
        public int CurrentLevel { get; set; }
    }
}
