using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public UserAddressService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddUserAddressRecord(UserAddressReq userAddress)
        {
            try
            {
                _context.SnUserAddresses.Add(_mapper.Map<SnUserAddress>(userAddress));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding userAddress. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteUserAddressRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUserAddresses.FirstOrDefault(t => t.Id == id);
                _context.SnUserAddresses.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting userAddress. Error:- " + ex.Message);
                return false;
            }
        }

        public List<UserAddressRes> GetUserAddressRecords()
        {
            try
            {
                return _mapper.Map<List<UserAddressRes>>(_context.SnUserAddresses.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving userAddress. Error:- " + ex.Message);
            }
            return new List<UserAddressRes>();
        }

        public UserAddressRes GetUserAddressSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<UserAddressRes>(_context.SnUserAddresses.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving userAddress. Error:- " + ex.Message);
            }
            return new UserAddressRes();
        }

        public bool UpdateUserAddressRecord(UserAddressReq userAddress)
        {
            try
            {
                _context.Update(_mapper.Map<SnUserAddress>(userAddress));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating userAddress. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
