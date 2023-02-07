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
    public interface IContainerLogService
    {
        bool AddContainerLogRecord(ContainerLogReq containerLog);
        bool UpdateContainerLogRecord(ContainerLogReq containerLog);
        bool DeleteContainerLogRecord(Guid id);
        ContainerLogRes GetContainerLogSingleRecord(Guid id);
        List<ContainerLogRes> GetContainerLogRecords(string clientId);
    }
}
