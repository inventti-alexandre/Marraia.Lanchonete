using Dominio.Kernel.Excecoes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace App.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {

        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;

            switch (exception)
            {
                case NotFoundException nfEx:
                    code = HttpStatusCode.NotFound;
                    break;
                case FieldsValidationException fvEx:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError; // 500 se for qualquer outro erro
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message, inner = exception.InnerException });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
