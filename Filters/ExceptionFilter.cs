using BookstoreManagement.Communication.Responses;
using BookstoreManagement.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookstoreManagement.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BookstoreManagementException productClientHubException)
        {
            context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido."));
    }
}
