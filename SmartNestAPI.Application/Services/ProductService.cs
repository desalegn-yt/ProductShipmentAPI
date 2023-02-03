using SmartNestAPI.Application.Core;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using AutoMapper;

namespace SmartNestAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public ProductService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public void AddProductRecord(ProductReq product)
        {
            try
            {
                _context.SnProducts.Add(_mapper.Map<SnProduct>(product));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding product. Error:- " + ex.Message);
            }
        }

        public void DeleteProductRecord(Guid id)
        {
            try
            {
                var entity = _context.SnProducts.FirstOrDefault(t => t.Id == id);
                _context.SnProducts.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting product. Error:- " + ex.Message);
            }
        }

        public List<ProductRes> GetProductRecords()
        {
            try
            {
                return _mapper.Map<List<ProductRes>>(_context.SnProducts.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving products. Error:- " + ex.Message);
            }
            return new List<ProductRes>();
        }

        public ProductRes GetProductSingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<ProductRes>(_context.SnProducts.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving products. Error:- " + ex.Message);
            }
            return new ProductRes();
        }

        public void UpdateProductRecord(ProductReq product)
        {
            try
            {
                _context.Update(_mapper.Map<SnProduct>(product));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating products. Error:- " + ex.Message);
            }
        }
    }
}
