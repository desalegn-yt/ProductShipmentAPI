﻿using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Database
{
    public partial class AlertMethodReq
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
