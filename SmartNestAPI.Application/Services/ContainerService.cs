using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class ContainerService : IContainerService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public ContainerService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddContainerRecord(ContainerReq container)
        {
            try
            {
                _context.SnContainers.Add(_mapper.Map<SnContainer>(container));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding Container. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteContainerRecord(Guid id)
        {
            try
            {
                var entity = _context.SnContainers.FirstOrDefault(t => t.Id == id);
                _context.SnContainers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting Container. Error:- " + ex.Message);
                return false;
            }
        }

        public List<ContainerRes> GetContainerRecords()
        {
            try
            {
                return _mapper.Map<List<ContainerRes>>(_context.SnContainers.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Containers. Error:- " + ex.Message);
            }
            return new List<ContainerRes>();
        }

        public ContainerRes GetContainerSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<ContainerRes>(_context.SnContainers.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Containers. Error:- " + ex.Message);
            }
            return new ContainerRes();
        }

        public bool UpdateContainerRecord(ContainerUpdateReq container)
        {
            try
            {
                var containerResult = _context.SnContainers.Where(u => u.Id == container.Id).FirstOrDefault();
                if (containerResult != null)
                {
                    containerResult.Name = container.Name;
                    containerResult.Description = container.Description;
                    _context.Update(containerResult);
                    _context.SaveChanges();
                    return true;
                }return false;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating Containers. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
