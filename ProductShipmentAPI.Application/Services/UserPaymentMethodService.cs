using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
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

        public bool AddUserPaymentMethodRecord(UserPaymentMethodReq userPaymentMethod, string clientID)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientID).Select(a => a.Id).FirstOrDefault();
                userPaymentMethod.UserId = userId;
                _context.SnUserPaymentMethods.Add(_mapper.Map<SnUserPaymentMethod>(userPaymentMethod));
                _context.SaveChanges();
                //User can only have one default payment
                if (userPaymentMethod.Default.Value)
                {
                    var userPaymentResult = _context.SnUserPaymentMethods.Where(u => u.Id != userPaymentMethod.Id && u.UserId == userPaymentMethod.UserId &&
                                                                                  u.Default == true).ToList();
                    if (userPaymentResult != null)
                    {
                        foreach(var userPayment in userPaymentResult)
                        {
                         userPayment.Default = false;
                        _context.Update(userPayment);
                        _context.SaveChanges();
                        }
                    }
                }
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

        public bool UpdateUserPaymentMethodRecord(UserPaymentMethodReq userPaymentMethod)
        {
            try
            {
                var userPaymentResult = _context.SnUserPaymentMethods.Where(u => u.Id == userPaymentMethod.Id).FirstOrDefault();
                if (userPaymentResult != null)
                {
                    userPaymentResult.Default = userPaymentMethod.Default;
                    _context.Update(userPaymentResult);
                    _context.SaveChanges();

                    //User can only have one default payment
                    var userPaymentList = _context.SnUserPaymentMethods.Where(u => u.Id != userPaymentResult.Id && u.UserId == userPaymentResult.UserId &&
                                                                                  u.Default == true).ToList();
                    if (userPaymentList != null)
                    {
                        foreach (var userPayment in userPaymentList)
                        {
                            userPayment.Default = false;
                            _context.Update(userPayment);
                            _context.SaveChanges();
                        }
                    }
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating UserPaymentMethods. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
