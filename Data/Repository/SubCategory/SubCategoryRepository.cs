using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    { 
        private readonly CartDbContext _context;
        public SubCategoryRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

    }
}