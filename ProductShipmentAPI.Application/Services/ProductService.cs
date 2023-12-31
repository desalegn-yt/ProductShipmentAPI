﻿using ProductShipmentAPI.Application.Core;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using AutoMapper;

namespace ProductShipmentAPI.Application.Services
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

        public bool AddProductRecord(ProductReq product)
        {
            try
            {
                _context.SnProducts.Add(_mapper.Map<SnProduct>(product));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while adding product. Error:- " + ex.Message);
                return false;
            }
        }

        public bool DeleteProductRecord(Guid id)
        {
            try
            {
                var entity = _context.SnProducts.FirstOrDefault(t => t.Id == id);
                _context.SnProducts.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while deleting product. Error:- " + ex.Message);
                return false;
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

        public bool UpdateProductRecord(ProductReq product)
        {
            try
            {
                _context.Update(_mapper.Map<SnProduct>(product));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logWriter.WriteLog("Error occured while updating products. Error:- " + ex.Message);
                return false;
            }
        }
    }
}
