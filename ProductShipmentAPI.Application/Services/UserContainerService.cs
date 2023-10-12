using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;
using System.ComponentModel;

namespace ProductShipmentAPI.Application.Services
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
                return _mapper.Map<List<UserContainerRes>>(_context.SnUserContainers.Where(t => t.UserId == userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving UserContainers. Error:- " + ex.Message);
            }
            return new List<UserContainerRes>();
        }

        public UserContainerDetailRes GetUserContainerSingleRecord(Guid id)
        {
            try
            {
                var userContainer = _mapper.Map<UserContainerDetailRes>(_context.SnUserContainers.FirstOrDefault(t => t.Id == id));
                userContainer.ContainerRules = _mapper.Map<List<ContainerRuleRes>>(_context.SnContainerRules.Where(t => t.ContainerId == id)).ToArray();
                userContainer.ContainerLogs = _mapper.Map<List<ContainerLogRes>>(_context.SnContainerLogs.Where(t => t.ContainerId == id).OrderByDescending(t => t.DateTimeStamp).Take(10)).ToArray();
                return userContainer;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving userContainers. Error:- " + ex.Message);
            }
            return new UserContainerDetailRes();
        }

        public bool UpdateUserContainerRecord(UserContainerReq userContainer)
        {
            try
            {
                var userContainerResult = _context.SnUserContainers.Where(u => u.Id == userContainer.Id).FirstOrDefault();
                if (userContainerResult != null)
                {
                    userContainerResult.Name = userContainer.Name;
                    userContainerResult.ProductId = userContainer.ProductId;
                    userContainerResult.CurrentLevel = userContainer.CurrentLevel;
                    userContainerResult.Photo = userContainer.Photo;
                    userContainerResult.CurrentLevel = userContainer.CurrentLevel;
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

    }
}
