using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public SupplierService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public void AddSupplierRecord(SupplierReq supplier)
        {
            try
            {
                _context.SnSuppliers.Add(_mapper.Map<SnSupplier>(supplier));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding Supplier. Error:- " + ex.Message);
            }
        }

        public void DeleteSupplierRecord(Guid id)
        {
            try
            {
                var entity = _context.SnSuppliers.FirstOrDefault(t => t.Id == id);
                _context.SnSuppliers.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting Supplier. Error:- " + ex.Message);
            }
        }

        public List<SupplierRes> GetSupplierRecords()
        {
            try
            {
                return _mapper.Map<List<SupplierRes>>(_context.SnSuppliers.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Suppliers. Error:- " + ex.Message);
            }
            return new List<SupplierRes>();
        }

        public SupplierRes GetSupplierSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<SupplierRes>(_context.SnSuppliers.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Suppliers. Error:- " + ex.Message);
            }
            return new SupplierRes();
        }

        public void UpdateSupplierRecord(SupplierReq Supplier)
        {
            try
            {
                _context.Update(_mapper.Map<SnSupplier>(Supplier));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating Suppliers. Error:- " + ex.Message);
            }
        }
    }
}
