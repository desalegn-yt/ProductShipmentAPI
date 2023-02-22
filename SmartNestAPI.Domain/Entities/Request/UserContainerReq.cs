using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class UserContainerReq
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? RefId { get; set; }
        public Guid? ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "Current level value must be between 1 and 100.")]
        public int? CurrentLevel { get; set; }
        public Guid UserId { get; set; }
    }
}
