using DatingAPP.Error;
using System.Net;
using System.Text.Json;

namespace DatingAPP.Middelware
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;
        ILogger<ExceptionMiddleware> _logger;
        IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware>logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) :
                      new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");
        
                var option =new JsonSerializerOptions {PropertyNamingPolicy= JsonNamingPolicy.CamelCase};

                var Json= JsonSerializer.Serialize(response, option);

                await context.Response.WriteAsync(Json);
            }
        }
    }
}
