using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CartDbContext _context;
        protected DbSet<TEntity> DbSet;

        public Repository(CartDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        private async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }


        public async Task AddOrUpdate(TEntity entity)
        {
            if (entity == null)
                return;

            if (entity.Id == null || entity.Id == Guid.Empty)
                await Add(entity);
            else
                await Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            await _context.RemoveAsync();
        }

        private async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
