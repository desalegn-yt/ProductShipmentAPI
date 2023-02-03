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

        public void AddUserContainerRecord(UserContainerReq UserContainer)
        {
            try
            {
                _context.SnUserContainers.Add(_mapper.Map<SnUserContainer>(UserContainer));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding UserContainer. Error:- " + ex.Message);
            }
        }

        public void DeleteUserContainerRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUserContainers.FirstOrDefault(t => t.Id == id);
                _context.SnUserContainers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting UserContainer. Error:- " + ex.Message);
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

        public void UpdateUserContainerRecord(UserContainerReq UserContainer)
        {
            try
            {
                _context.Update(_mapper.Map<SnUserContainer>(UserContainer));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating UserContainers. Error:- " + ex.Message);
            }
        }

        public void UpdateUserContainerRecord(ContainerReq container)
        {
            throw new NotImplementedException();
        }
    }
}
