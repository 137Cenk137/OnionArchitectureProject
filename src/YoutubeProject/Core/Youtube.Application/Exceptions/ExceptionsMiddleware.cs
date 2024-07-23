using System.Security.Cryptography;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace Youtube.Application.Exceptions;

public class ExceptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex )
        {
            
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        int statusCode = GetStatusCode(ex);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
       

 
        if(ex.GetType() == typeof(ValidationException))
        {
            return  httpContext.Response.WriteAsync(new ExceptionModel()
            {
                Errors = ((ValidationException)ex).Errors.Select(e => e.ErrorMessage),
                StatusCode = StatusCodes.Status400BadRequest
            }.ToString());
        }
    
        List<string> errors = new List<string>(){
            ex.Message,
        };
        if(ex.InnerException is not null)
        {
            errors.Add(ex.InnerException.ToString()); 
        }
        return httpContext.Response.WriteAsync(new ExceptionModel(){
            Errors = errors,
            StatusCode = statusCode 
        }.ToString());

    }

    private static int GetStatusCode(Exception ex) => ex switch{ 
        BadRequestException => StatusCodes.Status400BadRequest,
        NotFoundException => StatusCodes.Status400BadRequest,
        ValidationException => StatusCodes.Status422UnprocessableEntity,
         _ => StatusCodes.Status500InternalServerError

    };
}
