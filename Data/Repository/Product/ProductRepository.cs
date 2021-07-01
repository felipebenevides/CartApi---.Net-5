﻿using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repository
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly CartDbContext _context;
        public ProductRepository(CartDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }

    }
}