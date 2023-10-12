using System;
using System.Collections.Generic;

namespace ProductShipmentAPI.Domain.Entities.Response
{
    public class UserContainerDetailRes : UserContainerRes
    {
        public virtual ContainerRuleRes[] ContainerRules { get; set; } 
        public virtual ContainerLogRes[] ContainerLogs { get; set; } 
    }
}
