using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddOrUpdate(Category entity)
        {
            await _categoryRepository.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetAll()
        {
            return  _categoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<List<Category>> ListMenu()
        {
            return await _categoryRepository.ListMenu();
        }

        public async Task Remove(Category entity)
        {
            await _categoryRepository.Remove(entity);
        }
    }
}
