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
    public interface ISupplierService
    {
        void AddSupplierRecord(SupplierReq supplier);
        void UpdateSupplierRecord(SupplierReq supplier);
        void DeleteSupplierRecord(Guid id);
        SupplierRes GetSupplierSingleRecord(Guid id);
        List<SupplierRes> GetSupplierRecords();
    }
}
