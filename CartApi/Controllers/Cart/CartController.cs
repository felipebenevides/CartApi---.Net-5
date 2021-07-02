using Domain.Entities;
using Domain.Interfaces.Service;
using Domain.Services.Cache;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ApiController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        private CacheService Cache => GetService<CacheService>();


        /// <summary>
        /// Salva carrinho de compras
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send-cart")]
        public async Task<IActionResult> SendCart([FromBody] Cart model)
        {
            try
            {
                await _cartService.AddOrUpdate(model);
                var key = $"{nameof(ProductController)}:{nameof(SendCart)}:{model.Id}";
                await Cache.SetAsync(key, model, TimeSpan.FromDays(1));
                return CustomResponse(model);
            }
            catch (Exception ex)
            {
                AddError("Erro ao salvar carrinho");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Lista carrinho pelo Id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-by-id/{cartId}")]
        public async Task<IActionResult> SearchCart(Guid cartId)
        {
            try
            {
                var key = $"{nameof(ProductController)}:{nameof(SearchCart)}:{cartId}";

                var vmCache = await Cache.GetAsync<Product>(key);
                if (vmCache != null)
                    return CustomResponse(vmCache);

                var result = await _cartService.GetById(cartId);

                if (result != null)
                    await Cache.SetAsync(key, result, TimeSpan.FromDays(1));


                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao buscar carrinho");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Lista todos carrinhos
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var key = $"{nameof(ProductController)}:{nameof(GetAll)}";

                var vmCache = await Cache.GetAsync<IEnumerable<Cart>>(key);
                if (vmCache != null)
                    return CustomResponse(vmCache);

                var result = await _cartService.GetAllAsync();

                if (result.Any())
                    await Cache.SetAsync(key, result, TimeSpan.FromMinutes(5));

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao buscar carrinho");
                return CustomResponse();
            }
        }

    }
}
