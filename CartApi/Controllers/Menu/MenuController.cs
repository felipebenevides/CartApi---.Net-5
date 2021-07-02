using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Controllers.Menu
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        //private readonly ICategoryService _categoryService;

        public MenuController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        /// <summary>
        /// Cadastra Categorias
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> RegisterMenuCategory([FromBody] Category model)
        {
            try
            {
                await _categoryService.AddOrUpdate(model);
                return CustomResponse(model);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Categoria");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cadastra Sub Categorias
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-sub-category")]
        public async Task<IActionResult> RegisterMenuSubCategory([FromBody] SubCategory model)
        {
            try
            {
                await _subCategoryService.AddOrUpdate(model);
                return CustomResponse(model);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Sub Categoria");
                return CustomResponse();
            }
        }


        [HttpGet]
        [Route("list-menu")]

        public async Task<IActionResult> ListMenu ()
        {
            try
            {
                var result = await _categoryService.ListMenu();
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Sub Categoria");
                return CustomResponse();
            }
        }

        [HttpGet]
        [Route("list-main-categories")]

        public async Task<IActionResult> ListMainCategories()
        {
            try
            {
                var result = await _categoryService.ListMenu();
                var filter = result.Where(w => w.IsMain).ToList();
                return CustomResponse(filter);
            }
            catch (Exception ex)
            {
                AddError("Erro ao cadastrar Sub Categoria");
                return CustomResponse();
            }
        }




    }
}
