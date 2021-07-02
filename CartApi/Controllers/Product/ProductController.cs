using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Controllers.Product
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



        [HttpGet]
        [Route("list-products-by-category/{idCategory}")]
        public async Task<IActionResult> ListProductByCategory(Guid idCategory)
        {
            try
            {
                var result = await _productService.GetAllAsync();
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Sub Categoria");
                return CustomResponse();
            }
        }



    }
}
