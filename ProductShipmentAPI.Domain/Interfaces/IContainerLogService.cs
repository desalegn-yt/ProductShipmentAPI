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
    public interface IContainerLogService
    {
        bool AddContainerLogRecord(ContainerLogReq containerLog);
        bool UpdateContainerLogRecord(ContainerLogReq containerLog);
        bool DeleteContainerLogRecord(Guid id);
        ContainerLogRes GetContainerLogSingleRecord(Guid id);
        List<ContainerLogRes> GetContainerLogRecords(string clientId);
    }
}
