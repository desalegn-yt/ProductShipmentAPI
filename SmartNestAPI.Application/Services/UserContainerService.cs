using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class UserContainerService : IUserContainerService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public UserContainerService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddUserContainerRecord(UserContainerReq UserContainer, string clientID)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientID).Select(a => a.Id).FirstOrDefault();
                UserContainer.UserId = userId;
                _context.SnUserContainers.Add(_mapper.Map<SnUserContainer>(UserContainer));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding UserContainer. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteUserContainerRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUserContainers.FirstOrDefault(t => t.Id == id);
                _context.SnUserContainers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting UserContainer. Error:- " + ex.Message);
                return false;
            }
        }

        public List<UserContainerRes> GetUserContainerRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<UserContainerRes>>(_context.SnUserContainers.Where(u => u.UserId == userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving UserContainers. Error:- " + ex.Message);
            }
            return new List<UserContainerRes>();
        }

        public UserContainerRes GetUserContainerSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<UserContainerRes>(_context.SnUserContainers.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving UserContainers. Error:- " + ex.Message);
            }
            return new UserContainerRes();
        }

        public bool UpdateUserContainerRecord(UserContainerReq userContainer)
        {
            try
            {
                var userContainerResult = _context.SnUserContainers.Where(u => u.Id == userContainer.Id).FirstOrDefault();
                if (userContainerResult != null)
                {
                    userContainerResult.Name = userContainer.Name;
                    _context.Update(userContainerResult);
                    _context.SaveChanges();
                    return true;
                }return false;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating UserContainers. Error:- " + ex.Message);
                return false;
            }
        }

        public void UpdateUserContainerRecord(ContainerReq container)
        {
            throw new NotImplementedException();
        }
    }
}
