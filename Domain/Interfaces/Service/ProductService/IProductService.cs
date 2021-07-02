using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IProductService : IService<Product>
    {
        Task<List<Product>> ListByCategoryId(Guid categoryId);

    }
}
