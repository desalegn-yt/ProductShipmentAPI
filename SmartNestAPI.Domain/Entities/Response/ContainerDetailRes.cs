using System;
using System.Collections.Generic;

namespace SmartNestAPI.Domain.Entities.Response
{
    public class ContainerDetailRes : ContainerRes
    {
        public virtual ContainerRuleRes[] ContainerRules { get; set; } 
        public virtual ContainerLogRes[] ContainerLogs { get; set; } 
    }
}
