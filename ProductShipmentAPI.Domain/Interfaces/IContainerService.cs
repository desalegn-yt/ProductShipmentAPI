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
    public interface IContainerService
    {
        bool AddContainerRecord(ContainerReq container);
        bool UpdateContainerRecord(ContainerUpdateReq container);
        bool DeleteContainerRecord(Guid id);
        ContainerRes GetContainerSingleRecord(Guid id);
        List<ContainerRes> GetContainerRecords();
    }
}
