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

        public void AddUserRecord(UserReq user)
        {
            try
            {
                _context.SnUsers.Add(_mapper.Map<SnUser>(user));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding user. Error:- " + ex.Message);
            }
        }

        public void DeleteUserRecord(Guid id)
        {
            try
            {
                var entity = _context.SnUsers.FirstOrDefault(t => t.Id == id);
                _context.SnUsers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting user. Error:- " + ex.Message);
            }
        }
        public UserRes GetUserRecord(string clientId)
        {
            try
            {
                var result = _context.SnUsers.FirstOrDefault(a => a.AuthId == clientId);
                return _mapper.Map<UserRes>(_context.SnUsers.FirstOrDefault(a=>a.AuthId== clientId));
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

        public void UpdateUserRecord(UserReq user)
        {
            try
            {
                _context.Update(_mapper.Map<SnUser>(user));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating users. Error:- " + ex.Message);
            }
        }
    }
}
