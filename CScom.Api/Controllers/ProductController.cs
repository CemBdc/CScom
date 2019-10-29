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

        [HttpPost]
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
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"; //TODO
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        { //TODO
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        { //TODO
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