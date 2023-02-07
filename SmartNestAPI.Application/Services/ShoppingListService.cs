using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public ShoppingListService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddShoppingListRecord(ShoppingListReq shoppingList)
        {
            try
            {
                _context.SnShoppingLists.Add(_mapper.Map<SnShoppingList>(shoppingList));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding ShoppingList. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteShoppingListRecord(Guid id)
        {
            try
            {
                var entity = _context.SnShoppingLists.FirstOrDefault(t => t.Id == id);
                _context.SnShoppingLists.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting ShoppingList. Error:- " + ex.Message);
                return false;
            }
        }

        public List<ShoppingListRes> GetShoppingListRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<ShoppingListRes>>(_context.SnShoppingLists.Where(u=>u.UserId==userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ShoppingLists. Error:- " + ex.Message);
            }
            return new List<ShoppingListRes>();
        }

        public ShoppingListRes GetShoppingListSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<ShoppingListRes>(_context.SnShoppingLists.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ShoppingLists. Error:- " + ex.Message);
            }
            return new ShoppingListRes();
        }

        public bool UpdateShoppingListRecord(ShoppingListReq shoppingList)
        {
            try
            {
                _context.Update(_mapper.Map<SnShoppingList>(shoppingList));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating ShoppingLists. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
