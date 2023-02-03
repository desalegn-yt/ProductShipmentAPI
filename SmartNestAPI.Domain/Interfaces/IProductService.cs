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
    public interface IProductService
    {
        bool AddProductRecord(ProductReq product);
        bool UpdateProductRecord(ProductReq product);
        bool DeleteProductRecord(Guid id);
        ProductRes GetProductSingleRecord(Guid id);
        List<ProductRes> GetProductRecords();
    }
}
