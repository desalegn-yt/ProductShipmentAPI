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
    public interface IProductService
    {
        bool AddProductRecord(ProductReq product);
        bool UpdateProductRecord(ProductReq product);
        bool DeleteProductRecord(Guid id);
        ProductRes GetProductSingleRecord(Guid id);
        List<ProductRes> GetProductRecords();
    }
}
