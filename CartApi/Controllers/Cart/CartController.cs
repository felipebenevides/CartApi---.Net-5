using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> SendCart(Guid cartId)
        {
            try
            {
                var result = await _cartService.GetById(cartId);
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
        public async Task<IActionResult> GetAll(Guid cartId)
        {
            try
            {
                var result = await _cartService.GetAllAsync();
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
