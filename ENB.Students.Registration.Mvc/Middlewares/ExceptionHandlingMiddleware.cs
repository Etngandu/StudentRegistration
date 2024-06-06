//using FluentValidation;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.MVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.SecurityTokenService;
using OpenQA.Selenium;
using System.Text.Json;

namespace ENB.Students.Registration.Mvc.Middlewares
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)

            };

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = statusCode;

          await  Task.CompletedTask;
           // await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ModelValidationException applicationException => applicationException.Title,
                _ => "Server Error"
            };

        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }

            return errors!;
        }
    }
    //public class ExceptionHandlingMiddleware : IMiddleware
    //{
    //    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    //    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;
    //    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    //    {
    //        try
    //        {
    //            await next(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, ex.Message);


    //           await HandleExceptionAsync(context,ex);


    //        }
    //    }

    //    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    //    {


    //        var response = new ProblemDetails
    //        {
    //            //title= GetTitle(exception),
    //            // detail = exception.Message,
    //            // errors = GetErrors(exception)
    //            Status = StatusCodes.Status400BadRequest,
    //            Type = "ValidationFailure",
    //            Title = "Validation error",
    //            Detail = "One or more validation errors has occurred"

    //        };

    //        // httpContext.Response.ContentType = "application/json";

    //        // httpContext.Response.StatusCode = statusCode;

    //        //  await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));

    //        if (exception is not null)
    //        {
    //            response.Extensions["errors"] = GetErrors(exception);
    //        }

    //        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

    //        await httpContext.Response.WriteAsJsonAsync(response);
    //    }

    //    private static string GetTitle(Exception exception) =>
    //        exception switch
    //        {
    //            ModelValidationException applicationException => applicationException.Title,
    //            _ => "Server Error"
    //        };

    //    private static IEnumerable<ValidationError> GetErrors(Exception exception)
    //    {
    //        IEnumerable<ValidationError>? errors= null;

    //        if (exception is ValidationExceptionMvc validationException)
    //        {
    //            errors = validationException.ValidationErrors;
    //        }

    //        return errors!;
    //    }
    //}
}
