using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SmartNestAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public UserService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddUserRecord(UserReq user)
        {
            try
            {
                _context.SnUsers.Add(_mapper.Map<SnUser>(user));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding user. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteUserRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUsers.FirstOrDefault(t => t.Id == id);
                _context.SnUsers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting user. Error:- " + ex.Message);
                return false;
            }
        }
        public UserRes GetUserRecord(string clientId)
        {
            try
            {
                var result = _mapper.Map<UserRes>(_context.SnUsers.FirstOrDefault(a => a.AuthId == clientId));
                result.AddressesCount = _context.SnUserAddresses.Count(a => a.Id == result.Id);
                result.ContainersCount = _context.SnUserContainers.Count(a => a.UserId == result.Id);
                result.PaymentMethodsCount = _context.SnUserPaymentMethods.Count(a => a.UserId == result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving users. Error:- " + ex.Message);
            }
            return new UserRes();
        }

        public UserRes GetUserSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<UserRes>(_context.SnUsers.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving users. Error:- " + ex.Message);
            }
            return new UserRes();
        }

        public bool UpdateUserRecord(UserReq user, string clientID)
        {
            try
            {
                var userResult = _context.SnUsers.Where(u => u.AuthId == clientID).FirstOrDefault();
                if (userResult != null)
                {
                    userResult.FirstName = user.FirstName;
                    userResult.LastName = user.LastName;
                    _context.Update(userResult);
                    _context.SaveChanges();
                    return true;
                }return false;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating users. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
