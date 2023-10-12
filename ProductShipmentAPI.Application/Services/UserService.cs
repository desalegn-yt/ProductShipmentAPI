using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductShipmentAPI.Application.Services
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
                var users = _mapper.Map<UserRes>(_context.SnUsers.FirstOrDefault(a => a.AuthId == clientId));
                users.AddressesCount = _context.SnUserAddresses.Count(a => a.UserId == users.Id);
                //users.ContainersCount = _context.SnUserContainers.Count(a => a.UserId == users.Id);
                users.PaymentMethodsCount = _context.SnUserPaymentMethods.Count(a => a.UserId == users.Id);
                return users;
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
                var user = _mapper.Map<UserRes>(_context.SnUsers.FirstOrDefault(t => t.Id == id));
                user.AddressesCount = _context.SnUserAddresses.Count(a => a.UserId == user.Id);
                user.ContainersCount = _context.SnUserContainers.Count(a => a.UserId == user.Id);
                user.PaymentMethodsCount = _context.SnUserPaymentMethods.Count(a => a.UserId == user.Id);
                return user;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving users. Error:- " + ex.Message);
            }
            return new UserRes();
        }

        public bool UpdateUserRecord(UserUpdateReq user, string clientID)
        {
            try
            {
                var userResult = _context.SnUsers.Where(u => u.AuthId == clientID).FirstOrDefault();
                if (userResult != null)
                {
                    userResult.FirstName = user.FirstName;
                    userResult.LastName = user.LastName;
                    userResult.PhoneNumber = user.PhoneNumber;
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
