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

        public void AddOrderRecord(OrderReq order)
        {
            try
            {
                _context.SnOrders.Add(_mapper.Map<SnOrder>(order));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding order. Error:- " + ex.Message);
            }
        }

        public void DeleteOrderRecord(Guid id)
        {
            try
            {
                var entity = _context.SnOrders.FirstOrDefault(t => t.Id == id);
                _context.SnOrders.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting order. Error:- " + ex.Message);
            }
        }

        public List<OrderRes> GetOrderRecords()
        {
            try
            {
                return _mapper.Map<List<OrderRes>>(_context.SnOrders.ToList());
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

        public void UpdateOrderRecord(OrderReq order)
        {
            try
            {
                _context.SnOrders.Update(_mapper.Map<SnOrder>(order));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating orders. Error:- " + ex.Message);
            }
        }
    }
}
