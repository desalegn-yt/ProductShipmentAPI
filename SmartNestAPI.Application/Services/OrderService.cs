using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public OrderService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddOrderRecord(OrderReq order)
        {
            try
            {
                _context.SnOrders.Add(_mapper.Map<SnOrder>(order));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding order. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteOrderRecord(Guid id)
        {
            try
            {
                var entity = _context.SnOrders.FirstOrDefault(t => t.Id == id);
                _context.SnOrders.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting order. Error:- " + ex.Message);
                return false;
            }
        }

        public List<OrderRes> GetOrderRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<OrderRes>>(_context.SnOrders.Where(u=>u.UserId==userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving orders. Error:- " + ex.Message);
            }
            return new List<OrderRes>();
        }

        public OrderRes GetOrderSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<OrderRes>(_context.SnOrders.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving orders. Error:- " + ex.Message);
            }
            return new OrderRes();
        }

        public bool UpdateOrderRecord(OrderReq order)
        {
            try
            {
                _context.Update(_mapper.Map<SnOrder>(order));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating orders. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
