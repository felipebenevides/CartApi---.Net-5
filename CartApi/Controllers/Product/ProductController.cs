using Domain.Entities;
using Domain.Interfaces.Service;
using Domain.Services.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private CacheService Cache => GetService<CacheService>();



        [HttpGet]
        [Route("list-products-by-category/{categoryId}")]
        public async Task<IActionResult> ListProductByCategory(Guid categoryId)
        {
            try
            {
                var key = $"{nameof(ProductController)}:{nameof(ListProductByCategory)}:{categoryId}";

                var vmCache = await Cache.GetAsync<IEnumerable<Product>>(key);
                if (vmCache != null)
                    return CustomResponse(vmCache);

                var result = await _productService.ListByCategoryId(categoryId);

                if (result.Any())
                    await Cache.SetAsync(key, result, TimeSpan.FromDays(1));


                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Sub Categoria");
                return CustomResponse();
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Product model)
        {
            try
            {
                await _productService.AddOrUpdate(model);
                return CustomResponse(model);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar produto");
                return CustomResponse();
            }
        }


    }
}
