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
    public interface IShoppingListService
    {
        bool AddShoppingListRecord(ShoppingListReq shoppingList, string clientID);
        bool UpdateShoppingListRecord(ShoppingListReq shoppingList);
        bool DeleteShoppingListRecord(Guid id);
        ShoppingListRes GetShoppingListSingleRecord(Guid id);
        List<ShoppingListRes> GetShoppingListRecords(string clientId);
    }
}
