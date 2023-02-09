using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Request
{
    public partial class SupplierProductSearchReq
    {
        public Guid Id { get; set; } 
        public Guid? CategoryId { get; set; }
    }
}
