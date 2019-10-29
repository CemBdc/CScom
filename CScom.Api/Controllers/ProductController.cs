using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CScom.Api.Common.Enum;
using CScom.Api.Filter;
using CScom.Api.Model;
using CScom.Api.Model.Product;
using CScom.Core.Base;
using CScom.Dto.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CScom.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController: BaseController
    {
        public ProductController(IServiceWrapper serviceWrapper)
            : base(serviceWrapper)
        {
        }

        [HttpPost("Add")]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Add([FromBody]BasketProduct model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(new ApiResultModel
                {
                    Code = (int)ApiResultMessageCode.RequestModelInvalidError,
                    Message = (ApiResultMessageCode.RequestModelInvalidError).ToString()
                });
            }

            var inStock = await _serviceWrapper.Product.CheckProductStock(model.ProductId);

            var basketDto = new ProductBasketDto
            {
                ProductId = model.ProductId,
                UserId = model.UserId,
                ProductCount = model.ProductCount,
                BasketId = model.BasketId
            };

            var isAdded = await _serviceWrapper.Product.AddToBasket(basketDto);

            var result = SetResultModel(model, isAdded);

            return Ok(result);

        }

        private static ApiResultModel SetResultModel(BasketProduct model, bool isAdded)
        {
            var result = new ApiResultModel();
            result.Code = isAdded ? (int)ApiResultMessageCode.ProductAddToBasketSuccess : (int)ApiResultMessageCode.ProductAddToBasketError;
            result.Message = ((ApiResultMessageCode)result.Code).ToString();
            result.Data = model;
            return result;
        }
    }
}