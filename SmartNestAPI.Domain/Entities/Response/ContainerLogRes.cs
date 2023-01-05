﻿using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ContainerLogRes
    {
        public Guid Id { get; set; }
        public string LogType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime DateTimeStamp { get; set; }
        public Guid ContainerId { get; set; }
        public Guid UserId { get; set; }
        public int Snoose { get; set; }
    }
}
