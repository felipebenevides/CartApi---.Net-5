using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.CategoryRepository
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