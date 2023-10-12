using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShipmentAPI.Domain.Interfaces
{
    public interface IContainerRuleService
    {
        bool AddContainerRuleRecord(ContainerRuleReq containerRule, string clientID);
        bool UpdateContainerRuleRecord(ContainerRuleReq containerRule);
        bool DeleteContainerRuleRecord(Guid id);
        ContainerRuleRes GetContainerRuleSingleRecord(Guid id);
        List<ContainerRuleRes> GetContainerRuleRecords(string clientId);
    }
}
