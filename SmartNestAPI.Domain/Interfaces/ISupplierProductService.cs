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
    public interface ISupplierProductService
    {
        bool AddSupplierProductRecord(SupplierProductReq supplierProduct);
        bool UpdateSupplierProductRecord(SupplierProductReq supplierProduct);
        bool DeleteSupplierProductRecord(Guid id);
        SupplierProductRes GetSupplierProductSingleRecord(Guid id, Guid? categoryId);
        List<SupplierProductRes> GetSupplierProductRecords();
    }
}
