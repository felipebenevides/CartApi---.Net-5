using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CartDbContext _context;
        public CategoryRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

    }
}