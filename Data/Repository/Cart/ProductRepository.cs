using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{

    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly CartDbContext _context;
        public CartRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

    }
}