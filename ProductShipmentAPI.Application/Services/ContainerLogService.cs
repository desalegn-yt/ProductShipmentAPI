using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
{
    public class ContainerLogService : IContainerLogService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public ContainerLogService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddContainerLogRecord(ContainerLogReq containerLog)
        {
            try
            {
                _context.SnContainerLogs.Add(_mapper.Map<SnContainerLog>(containerLog));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding ContainerLog. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteContainerLogRecord(Guid id)
        {
            try
            {
                var entity = _context.SnContainerLogs.FirstOrDefault(t => t.Id == id);
                _context.SnContainerLogs.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting ContainerLog. Error:- " + ex.Message);
                return false;
            }
        }

        public List<ContainerLogRes> GetContainerLogRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<ContainerLogRes>>(_context.SnContainerLogs.Where(cr => cr.UserId == userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ContainerLogs. Error:- " + ex.Message);
            }
            return new List<ContainerLogRes>();
        }

        public ContainerLogRes GetContainerLogSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<ContainerLogRes>(_context.SnContainerLogs.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ContainerLogs. Error:- " + ex.Message);
            }
            return new ContainerLogRes();
        }

        public bool UpdateContainerLogRecord(ContainerLogReq containerLog)
        {
            try
            {
                _context.SnContainerLogs.Update(_mapper.Map<SnContainerLog>(containerLog));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating ContainerLogs. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
