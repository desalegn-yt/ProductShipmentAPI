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
    public interface IContainerService
    {
        void AddContainerRecord(ContainerReq container);
        void UpdateContainerRecord(ContainerReq container);
        void DeleteContainerRecord(Guid id);
        ContainerRes GetContainerSingleRecord(Guid id);
        List<ContainerRes> GetContainerRecords();
    }
}
