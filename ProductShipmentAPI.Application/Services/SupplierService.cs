using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
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

        public bool AddSupplierRecord(SupplierReq supplier)
        {
            try
            {
                _context.SnSuppliers.Add(_mapper.Map<SnSupplier>(supplier));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding Supplier. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteSupplierRecord(Guid id)
        {
            try
            {
                var entity = _context.SnSuppliers.FirstOrDefault(t => t.Id == id);
                _context.SnSuppliers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting Supplier. Error:- " + ex.Message);
                return false;
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

        public bool UpdateSupplierRecord(SupplierReq Supplier)
        {
            try
            {
                _context.Update(_mapper.Map<SnSupplier>(Supplier));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating Suppliers. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
