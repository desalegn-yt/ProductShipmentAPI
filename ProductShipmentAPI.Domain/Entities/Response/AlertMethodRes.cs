﻿using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class AlertMethodRes
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
