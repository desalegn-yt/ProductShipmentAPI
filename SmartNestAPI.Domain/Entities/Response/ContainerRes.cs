using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ContainerRes
    {
        public string Name { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal Capacity { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public bool IsVisible { get; set; }
        public string Images { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? AdminNote { get; set; }
        public int PreorderQty { get; set; }
        public bool Preorder { get; set; }
        public string PreorderText { get; set; } = null!;
        public Guid Id { get; set; }
        public string Photo { get; set; } = null!;
        public string RefId { get; set; } = null!;
        public Guid? ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "Current level value must be between 1 and 100.")]
        public int CurrentLevel { get; set; }



    }
}
