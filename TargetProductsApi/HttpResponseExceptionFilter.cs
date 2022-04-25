using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TargetProductsApi.Exceptions;

namespace TargetProductsApi;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is TargetResourceNotFoundException)
        {
            context.Result = new ObjectResult("Not found.")
            {
                StatusCode = 404,
            };

            context.ExceptionHandled = true;
        }
    }
}
