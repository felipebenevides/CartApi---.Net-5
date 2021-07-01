using Domain.Interfaces.Service.IMenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.MenuService
{
    public class CategoryService : ICategoryService
    {
        public Task AddOrUpdate(ICategoryService entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICategoryService> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICategoryService>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICategoryService> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(ICategoryService entity)
        {
            throw new NotImplementedException();
        }
    }
}
