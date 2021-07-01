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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task AddOrUpdate(SubCategory entity)
        {
            await _subCategoryRepository.AddOrUpdate(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _subCategoryRepository.GetAll();
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await _subCategoryRepository.GetAllAsync();
        }

        public async Task<SubCategory> GetById(Guid id)
        {
            return await _subCategoryRepository.GetByIdAsync(id);
        }

        public async Task Remove(SubCategory entity)
        {
            await _subCategoryRepository.Remove(entity);
        }
    }
}
