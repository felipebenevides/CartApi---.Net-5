using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task AddOrUpdate(Cart entity)
        {
            await _cartRepository.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Cart> GetAll()
        {
            return  _cartRepository.GetAll();
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _cartRepository.GetAllAsync();
        }

        public async Task<Cart> GetById(Guid id)
        {
            return await _cartRepository.GetByIdAsync(id);
        }

        public async Task Remove(Cart entity)
        {
            await _cartRepository.Remove(entity);
        }
    }
}
