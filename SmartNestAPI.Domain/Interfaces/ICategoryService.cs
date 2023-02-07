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
    public interface ICategoryService
    {
        bool AddCategoryRecord(CategoryReq category);
        bool UpdateCategoryRecord(CategoryReq category);
        bool DeleteCategoryRecord(Guid id);
        CategoryRes GetCategorySingleRecord(Guid id);
        List<CategoryRes> GetCategoryRecords();
    }
}
