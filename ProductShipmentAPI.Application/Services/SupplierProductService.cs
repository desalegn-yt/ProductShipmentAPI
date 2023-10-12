using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
{
    public class SupplierProductService : ISupplierProductService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public SupplierProductService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddSupplierProductRecord(SupplierProductReq supplierProduct)
        {
            try
            {
                _context.SnSupplierProducts.Add(_mapper.Map<SnSupplierProduct>(supplierProduct));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding SupplierProduct. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteSupplierProductRecord(Guid id)
        {
            try
            {
                var entity = _context.SnSupplierProducts.FirstOrDefault(t => t.Id == id);
                _context.SnSupplierProducts.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting SupplierProduct. Error:- " + ex.Message);
                return false;
            }
        }

        public List<SupplierProductRes> GetSupplierProductRecords()
        {
            try
            {
                return _mapper.Map<List<SupplierProductRes>>(_context.SnSupplierProducts.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving SupplierProducts. Error:- " + ex.Message);
            }
            return new List<SupplierProductRes>();
        }

        public SupplierProductRes GetSupplierProductSingleRecord(Guid id, Guid? categoryId)
        {
            try
            {
                if (categoryId == null)
                {
                    return _mapper.Map<SupplierProductRes>(_context.SnSupplierProducts.FirstOrDefault(t => t.Id == id));
                }
                else
                {
                    return _mapper.Map<SupplierProductRes>(_context.SnSupplierProducts.FirstOrDefault(t => t.Id == id && t.CategoryId == categoryId));
                }
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving SupplierProducts. Error:- " + ex.Message);
            }
            return new SupplierProductRes();
        }

        public bool UpdateSupplierProductRecord(SupplierProductReq supplierProduct)
        {
            try
            {
                _context.Update(_mapper.Map<SnSupplierProduct>(supplierProduct));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating SupplierProducts. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
