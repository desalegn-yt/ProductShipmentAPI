using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class UserPaymentMethodService : IUserPaymentMethodService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public UserPaymentMethodService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod)
        {
            try
            {
                _context.SnUserPaymentMethods.Add(_mapper.Map<SnUserPaymentMethod>(UserPaymentMethod));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding UserPaymentMethod. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteUserPaymentMethodRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUserPaymentMethods.FirstOrDefault(t => t.Id == id);
                _context.SnUserPaymentMethods.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting UserPaymentMethod. Error:- " + ex.Message);
                return false;
            }
        }

        public List<UserPaymentMethodRes> GetUserPaymentMethodRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<UserPaymentMethodRes>>(_context.SnUserPaymentMethods.Where(u => u.UserId == userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving UserPaymentMethods. Error:- " + ex.Message);
            }
            return new List<UserPaymentMethodRes>();
        }

        public UserPaymentMethodRes GetUserPaymentMethodSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<UserPaymentMethodRes>(_context.SnUserPaymentMethods.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving UserPaymentMethods. Error:- " + ex.Message);
            }
            return new UserPaymentMethodRes();
        }

        public bool UpdateUserPaymentMethodRecord(UserPaymentMethodReq UserPaymentMethod)
        {
            try
            {
                _context.Update(_mapper.Map<SnUserPaymentMethod>(UserPaymentMethod));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating UserPaymentMethods. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
