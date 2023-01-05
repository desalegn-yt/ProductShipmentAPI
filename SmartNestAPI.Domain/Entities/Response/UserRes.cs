﻿using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class UserRes
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime DateCreate { get; set; }
        public string AuthId { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? ProfileUrl { get; set; }
        public string? UserName { get; set; }
    }
}