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
    public interface ISupplierService
    {
        bool AddSupplierRecord(SupplierReq supplier);
        bool UpdateSupplierRecord(SupplierReq supplier);
        bool DeleteSupplierRecord(Guid id);
        SupplierRes GetSupplierSingleRecord(Guid id);
        List<SupplierRes> GetSupplierRecords();
    }
}
