using CScom.Api.Common.Enum;
using CScom.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;


namespace CScom.Api.Filter
{
    public class ValidationFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IModel);
            var resultCode = 0;

            if (param.Value == null)
                resultCode = (int)ApiResultMessageCode.RequestModelNullError;

            else if (!context.ModelState.IsValid)
                resultCode = (int)ApiResultMessageCode.RequestModelInvalidError;

            if (resultCode != 0)
            {
                context.Result = new BadRequestObjectResult(new ApiResultModel
                {
                    Code = resultCode,
                    Message = ((ApiResultMessageCode)resultCode).ToString()
                }); 
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        
    }
}
