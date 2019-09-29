using CScom.Api.Controllers;
using CScom.Api.Model;
using CScom.Api.Model.Product;
using CScom.Core.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;

namespace CScom.Test
{
    public class ProductTest
    {
        protected IServiceWrapper _serviceWrapper;
        protected ProductController _productController;

        public ProductTest()
        {
            var serviceProvider = new ServiceCollection()
                                        .AddLogging()
                                        .BuildServiceProvider();

            var factory = serviceProvider.GetService<IServiceWrapper>();
            _productController = new ProductController(factory);

        }

        [Fact]
        public void Get_InvalidResultCode_When_Null_RequestModel()
        {
            var taskData = _productController.AddBasket(null);
            
            var result = taskData.Result as BadRequestObjectResult;
            var obj = result.Value as ApiResultModel;
            Assert.Equal("603", obj.Code.ToString());
            
        }

        [Fact]
        public void Get_BadRequestStatus_When_Null_RequestModel()
        {
            var taskData = _productController.AddBasket(null);

            var result = taskData.Result as BadRequestObjectResult;
            var obj = result.Value as ApiResultModel;
            Assert.Equal("400", result.StatusCode.Value.ToString());
            
        }

        [Theory]
        [InlineData("", "userid1", "basketid1", "productname1", 1)]
        [InlineData("productid1", "", "basketid2", "productname2", 2)]
        [InlineData("productid2", "userid2", "", "productname3", 3)]
        [InlineData("productid3", "userid3", "basketid3", "", 1)]
        [InlineData("productid4", "userid4", "basketid4", "productname4", 0)]
        public void Get_ModelStateError_When_Invalid_RequestModel(string productId, string userId, string basketId, string productName, int productCount)
        {
            var lstErrors = ValidateModel(new BasketProduct
            {
                ProductId = productId,
                UserId = userId,
                BasketId = basketId,
                ProductName = productName,
                ProductCount = productCount
            });

            Assert.True(lstErrors.Count == 1);
            
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
