﻿using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class UserRes
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateCreate { get; set; }
        public string AuthId { get; set; } = null!;
        public string Status { get; set; } = null!;
        //public string? ProfileUrl { get; set; }
        //public string? UserName { get; set; }
        public long AddressesCount { get; set; }
        public long PaymentMethodsCount { get; set; }
        public long ContainersCount { get; set; }
    }
}
