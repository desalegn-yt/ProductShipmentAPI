using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PostgreSqlContext _context;
        private readonly IMapper _mapper;
        private readonly LogWriter _logWriter;

        public CategoryService(PostgreSqlContext context, IMapper mapper, LogWriter logWriter)
        {
            _context = context;
            _mapper = mapper;
            _logWriter = logWriter;
        }

        public bool AddCategoryRecord(CategoryReq category)
        {
            try
            {
                _context.SnCategories.Add(_mapper.Map<SnCategory>(category));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding Category. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteCategoryRecord(Guid id)
        {
            try
            {
                var entity = _context.SnCategories.FirstOrDefault(t => t.Id == id);
                _context.SnCategories.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting Category. Error:- " + ex.Message);
                return false;
            }
        }

        public List<CategoryRes> GetCategoryRecords()
        {
            try
            {
                return _mapper.Map<List<CategoryRes>>(_context.SnCategories.ToList());
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Categories. Error:- " + ex.Message);
            }
            return new List<CategoryRes>();
        }

        public CategoryRes GetCategorySingleRecord(Guid id)
        {
            try
            {
                return _mapper.Map<CategoryRes>(_context.SnCategories.FirstOrDefault(t => t.Id == id));
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while retrieving Categories. Error:- " + ex.Message);
            }
            return new CategoryRes();
        }

        public bool UpdateCategoryRecord(CategoryReq category)
        {
            try
            {
                _context.SnCategories.Update(_mapper.Map<SnCategory>(category));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating Categories. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
