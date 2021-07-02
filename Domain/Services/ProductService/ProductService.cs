using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddOrUpdate(Product entity)
        {
            await _productRepository.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Product> GetAll()
        {
            return  _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task Remove(Product entity)
        {
            await _productRepository.Remove(entity);
        }

        public async Task<List<Product>>ListByCategory(Guid idCategory)
        {
            // var result = _productRepository.Ge

            return null;
        }
    }
}
