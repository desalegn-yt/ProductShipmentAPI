using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
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

        public bool AddUserAddressRecord(UserAddressReq userAddress, string clientID)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientID).Select(a => a.Id).FirstOrDefault();
                userAddress.UserId = userId;
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

        public List<UserAddressRes> GetUserAddressRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<UserAddressRes>>(_context.SnUserAddresses.Where(u => u.UserId == userId).ToList());
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
                var userAddressResult = _context.SnUserAddresses.Where(u => u.Id == userAddress.Id).FirstOrDefault();
                if (userAddressResult != null)
                {
                    userAddressResult.Address1 = userAddress.Address1;
                    userAddressResult.Address2 = userAddress.Address2;
                    userAddressResult.ContactNumber = userAddress.ContactNumber;
                    userAddressResult.Suburb = userAddress.Suburb;
                    userAddressResult.Postcode = userAddress.Postcode;
                    _context.Update(userAddressResult);
                    _context.SaveChanges();
                    return true;
                }return false;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating userAddress. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
