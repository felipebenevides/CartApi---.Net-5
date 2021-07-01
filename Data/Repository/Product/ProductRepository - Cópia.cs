using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductRepository _productRepository;
        public ProductRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddOrUpdate(Product entity)
        {
            await _productRepository.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Product GetById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task Remove(Product entity)
        {
            await _productRepository.Remove(entity);
        }
    }
}
