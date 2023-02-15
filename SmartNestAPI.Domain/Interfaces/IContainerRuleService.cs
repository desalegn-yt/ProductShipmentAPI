using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNestAPI.Domain.Interfaces
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
