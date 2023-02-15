using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class ContainerRuleService : IContainerRuleService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public ContainerRuleService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddContainerRuleRecord(ContainerRuleReq containerRule, string clientID)
        {
            try
            {
                //make sure productId is valid supplier product
                //var supplierProduct = _context.SnSupplierProducts.FirstOrDefault(sp => sp.Id == containerRule.ProductId);
                //if (supplierProduct == null) return false;
                var userId = _context.SnUsers.Where(u => u.AuthId == clientID).Select(a => a.Id).FirstOrDefault();
                containerRule.UserId = userId;
                _context.SnContainerRules.Add(_mapper.Map<SnContainerRule>(containerRule));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding ContainerRule. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteContainerRuleRecord(Guid id)
        {
            try
            {
                var entity = _context.SnContainerRules.FirstOrDefault(t => t.Id == id);
                _context.SnContainerRules.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting ContainerRule. Error:- " + ex.Message);
                return false;
            }
        }

        public List<ContainerRuleRes> GetContainerRuleRecords(string clientId)
        {
            try
            {
                var userId = _context.SnUsers.Where(u => u.AuthId == clientId).Select(a => a.Id).FirstOrDefault();
                return _mapper.Map<List<ContainerRuleRes>>(_context.SnContainerRules.Where(cr => cr.UserId == userId).ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ContainerRules. Error:- " + ex.Message);
            }
            return new List<ContainerRuleRes>();
        }

        public ContainerRuleRes GetContainerRuleSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<ContainerRuleRes>(_context.SnContainerRules.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving ContainerRules. Error:- " + ex.Message);
            }
            return new ContainerRuleRes();
        }

        public bool UpdateContainerRuleRecord(ContainerRuleReq containerRule)
        {
            try
            {
                _context.SnContainerRules.Update(_mapper.Map<SnContainerRule>(containerRule));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating ContainerRules. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
