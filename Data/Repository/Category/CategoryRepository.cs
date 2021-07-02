using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CartDbContext _context;
        public CategoryRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public async Task<List<Category>> ListMenu()
        {
            var result = await _context.Categories.AsNoTracking().Include(i => i.SubCategories).ToListAsync();
            return result;
        }

    }
}