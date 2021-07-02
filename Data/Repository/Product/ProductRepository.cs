using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly CartDbContext _context;
        public ProductRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

        public async Task<List<Product>> ListByCategoryId(Guid categoryId)
        {
            var result = await _context.Products
                .Where(w => w.Category != null && w.Category.CategoryId == categoryId)
                .AsNoTracking()
                //.Include(i => i.Images)
                .ToListAsync();

            return result;
        }

    }
}