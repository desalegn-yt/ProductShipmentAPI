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
    public interface ISupplierProductService
    {
        bool AddSupplierProductRecord(SupplierProductReq supplierProduct);
        bool UpdateSupplierProductRecord(SupplierProductReq supplierProduct);
        bool DeleteSupplierProductRecord(Guid id);
        SupplierProductRes GetSupplierProductSingleRecord(Guid id, Guid? categoryId);
        List<SupplierProductRes> GetSupplierProductRecords();
    }
}
