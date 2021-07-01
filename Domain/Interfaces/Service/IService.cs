using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        Task AddOrUpdate(TEntity entity);
        Task Remove(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
